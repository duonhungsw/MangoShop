namespace Mango.Service.OrderAPI.Models.Dto
{
	public class AccountDto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string? PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string? PictureUrl { get; set; }
		public bool IsDeleted { get; set; }
	}
}
