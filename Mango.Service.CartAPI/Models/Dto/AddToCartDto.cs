namespace Mango.Service.CartAPI.Models.Dto;

public class AddToCartDto
{
	public Guid ProductId { get; set; }
	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public string? Token { get; set; }
}
