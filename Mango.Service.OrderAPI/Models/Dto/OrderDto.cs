using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Service.OrderAPI.Models.Dto;

public class OrderDto
{
	public Guid Id { get; set; }
	public Guid AccountId { get; set; }
	public Guid CouponId { get; set; }
	[NotMapped] 
	public string? provinceName { get; set; }
	[NotMapped]

	public string? districtName { get; set; }
	[NotMapped]

	public string? wardName { get; set; }
	public string? Address { get; set; }
	public string? Phone { get; set; }
	public string? Note { get; set; }
	public decimal TotalMoney { get; set; }
}
