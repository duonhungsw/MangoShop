namespace Mango.Service.AccountAPI.Service.Interfaces
{
    public interface IPasswordResetService
    {
        Task<string> GeneratePasswordResetToken(string email);
        Task<bool> ValidatePasswordResetToken(string token, string email);
        Task ResetPassword(string email, string newPassword);
    }
}
