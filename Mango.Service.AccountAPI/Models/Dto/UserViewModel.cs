namespace Mango.Service.AccountAPI.Models.Dto
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
        public string? PictureUrl { get; set; }
        public bool IsDeleted { get; set; }
        public  RoleViewModel RoleViewModel { get; set; }
    }
}
