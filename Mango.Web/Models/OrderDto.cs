namespace Mango.Web.Models
{
	public class OrderDto
	{
		public Guid AccountId { get; set; }
		public Guid CouponId { get; set; }
		public string? provinceName { get; set; }
		public string? districtName { get; set; }
		public string? wardName { get; set; }
		public string? Address { get; set; }
		public string? Phone { get; set; }
		public string? Note { get; set; }
		public decimal TotalMoney { get; set; }
	}
}
