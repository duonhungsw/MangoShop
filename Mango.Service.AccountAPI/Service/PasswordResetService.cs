using Book.Core.Interfaces;
using Common.Extensions;
using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mango.Service.AccountAPI.Service;

public class PasswordResetService : IPasswordResetService
{
    private readonly IConfiguration _configuration;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

    public PasswordResetService(IConfiguration configuration, ITokenService tokenService,
        IAccountService accountService, IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _tokenService = tokenService;
        _accountService = accountService;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> GeneratePasswordResetToken(string email)
    {
        var user = await _accountService.GetUserByEmail(email);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

        // Create token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
            Expires = DateTime.UtcNow.AddMinutes(30), // Token expires in 30 minutes
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        // Create the token
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        // Save the token to redis (or in-memory cache)
        var resetToken = new PasswordResetToken
        {
            Id = Guid.NewGuid(),
            Email = email,
            Token = tokenString,
            ExpiryDate = DateTime.UtcNow.AddMinutes(30) // Expiration
        };

        // Save resetToken to the redis
        await _tokenService.SetTokenAsync(resetToken);

        return tokenString;
    }

    public async Task<bool> ValidatePasswordResetToken(string token, string email)
    {
        var resetToken = await _tokenService.GetTokenAsync(email);
        if (resetToken == null || resetToken.ExpiryDate < DateTime.UtcNow)
        {
            return false; // Token không tồn tại hoặc đã hết hạn
        }

        // Validate token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return true; // Token hợp lệ
        }
        catch
        {
            return false; // Token không hợp lệ
        }
    }

    public async Task ResetPassword(string email, string newPassword)
    {
        var user = await _accountService.GetUserByEmail(email);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        // Hash mật khẩu mới và lưu lại
        byte[] salt;
        string hashedPassword = PasswordHasher.HashPasswordPBKDF2(newPassword, out salt);
        user.Password = hashedPassword;

        // Update user
        _accountService.Update(user);


        // Xóa token reset password sau khi thành công
        await _tokenService.DeleteTokenAsync(email);
    }
}
