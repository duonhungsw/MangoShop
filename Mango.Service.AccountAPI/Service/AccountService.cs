using Book.Core.Interfaces;
using Common.Entities;
using Common.Extensions;
using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mango.Service.AccountAPI.Service;

public interface IAccountService
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();

    void Delete(User entity);
    void Update(User entity);
    void Create(User entity);
    bool Exist(Guid id);
    Role? GetRoleByNameAsync(string Name);
    Role? GetRoleByIdAsync(int id);
    Task<string?> Login(string Email, string Password, HttpContext httpContext);
    Task<User> GetUserByEmail(string Email);
}
public class AccountService(IUnitOfWork unitOfWork, IRoleRepository roleRepository,
                            IAccountRepository userRepository, IConfiguration configuration) : IAccountService
{
    public  void Create(User entity)
    {
        var roleExist = GetRoleByNameAsync(BaseRole.Employee.ToString());
        Role employeeRole;

        if (roleExist == null)
        {
            employeeRole = new Role { RoleName = BaseRole.Employee.ToString() };
            unitOfWork.Repository<Role>().Create(employeeRole);
            entity.Role =  employeeRole;
        }
        else
        {
            entity.Role = roleExist;
        }
        entity.Id = Guid.NewGuid();
        byte[] salt;
        string hashPassword = PasswordHasher.HashPasswordPBKDF2(entity.Password, out salt);
        entity.Password = hashPassword;

        unitOfWork.Repository<User>().Create(entity);
    }

    public void Delete(User entity) => unitOfWork.Repository<User>().Delete(entity);
    public bool Exist(Guid id) => unitOfWork.Repository<User>().Exist(id);
    public Task<IEnumerable<User>> GetAllAsync() => unitOfWork.Repository<User>()
                                                    .GetAllAsync(query => query.Include(x => x.Role));
    public async Task<User?> GetByIdAsync(Guid id) => await unitOfWork.Repository<User>().GetByIdAsync(id);

    public Role? GetRoleByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Role GetRoleByNameAsync(string Name)
        => roleRepository.GetRoleByNameAsync(Name);

    public async Task<User?> GetUserByEmail(string email) => await userRepository.GetObject<User>(x => x.Email == email);
   
    public async Task<string?> Login(string Email, string Password, HttpContext httpContext)
    {
        var customerExist = await userRepository.GetObject<User>(x => x.Email == Email);
        if (customerExist == null)
        {
            throw new Exception("Email không tồn tại.");
        }

        bool isPasswordValid = PasswordHasher.VerifyPasswordPBKDF2(Password, customerExist.Password);
        if (isPasswordValid == false)
        {
            throw new Exception("Mật khẩu không đúng.");
        }

        // Tạo claims cho JWT
        var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, customerExist.Email),
        new Claim(ClaimTypes.NameIdentifier, customerExist.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //new Claim(ClaimTypes.Role, customerExist.Role.RoleName) // Thêm vai trò
    };

        // Tạo khóa bí mật cho JWT
        var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

        // Tạo JWT
        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.UtcNow.AddMinutes(20),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
        );

        // Ghi token vào cookie
        httpContext.Response.Cookies.Append("JWTToken", new JwtSecurityTokenHandler().WriteToken(token), new CookieOptions
        {
            HttpOnly = true, // Không cho phép JavaScript truy cập cookie này
            Expires = DateTime.UtcNow.AddMinutes(20) // Thời gian hết hạn của cookie
        });

        // Trả về token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public void Update(User entity) => unitOfWork.Repository<User>().Update(entity);
}
