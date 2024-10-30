using Mango.Service.OrderAPI.Models;
using Mango.Service.OrderAPI.Models.Dto;

namespace Mango.Service.OrderAPI.Mappings;

public  class OrderItemMapping
{
	public  OrderItemDto AddOrderItemMap(  CartItemDto cartItemDto, Guid orderId)
	{
		return new OrderItemDto
		{
			Id = cartItemDto.Id,
			OrderId = orderId,
			ProductId = cartItemDto.ProductId,
			Price = cartItemDto.Price,
			PriceTotal = cartItemDto.Total_money,
			Quantity = cartItemDto.Quantity,
		};
	}
}
