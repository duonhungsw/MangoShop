namespace Mango.Service.AccountAPI.Models
{
    public class PasswordResetToken
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; } 
    }
}
