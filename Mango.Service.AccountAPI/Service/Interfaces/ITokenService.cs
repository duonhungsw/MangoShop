using Mango.Service.AccountAPI.Models;

namespace Mango.Service.AccountAPI.Service.Interfaces;

public interface ITokenService
{
    Task<PasswordResetToken?> GetTokenAsync(string key);
    Task<PasswordResetToken?> SetTokenAsync(PasswordResetToken cart);
    Task<bool> DeleteTokenAsync(string key);
}
