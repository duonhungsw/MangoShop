namespace Mango.Service.OrderAPI.Models.Dto;

public class OrderItemDto
{
	public Guid Id { get; set; }
	public Guid OrderId { get; set; }
	public Guid ProductId { get; set; }
	public decimal? Price { get; set; }
	public decimal? PriceTotal { get; set; }
	public int Quantity { get; set; }
}
