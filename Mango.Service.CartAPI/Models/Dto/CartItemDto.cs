namespace Mango.Service.CartAPI.Models.Dto;

public class CartItemDto
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total_money { get; set; }
    public bool Status { get; set; }
}
