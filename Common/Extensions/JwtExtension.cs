using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.Extensions;

public static class JwtExtension
{
    public static string? GetToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var claims = jwtToken.Claims;

        var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var accountId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return accountId;
    }
}
