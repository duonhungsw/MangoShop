using AutoMapper;
using Book.Core.Interfaces;
using Mango.Service.OrderAPI.Mappings;
using Mango.Service.OrderAPI.Models;
using Mango.Service.OrderAPI.Models.Dto;
using Mango.Service.OrderAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Service.OrderAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService orderService,
							ICartService cartService,
							IUnitOfWork unitOfWork,
							IHttpContextAccessor _contextAccessor,
							IMapper mapper) : ControllerBase
{
	[HttpGet]
	public async Task<ResponseDto> ListOrder()
	{
		var lists = await orderService.GetAllAsync();
		return new ResponseDto
		{
			IsSuccess = true,
			Result = lists
		};
	}
	[HttpGet("get-by-id")]
	public async Task<ResponseDto> GetById(Guid id)
	{
		var order = await orderService.GetByIdAsync(id);
		return new ResponseDto
		{
			IsSuccess = true,
			Result = order
		};
	}
	[HttpPost("Order")]
	public async Task<ActionResult<ResponseDto>> Order(OrderDto orderDto)
	{
		orderDto.Address += ", " + orderDto.provinceName + ", " + orderDto.districtName + ", " + orderDto.wardName;

		var order = mapper.Map<Order>(orderDto);
		orderService.Create(order);

		if (await unitOfWork.Complete())
		{
			//Response CartItem with status true
			var listOrderItem = await cartService.GetOrders(orderDto.AccountId);

			foreach (var item in listOrderItem)
			{
				OrderItemMapping itemMapping = new OrderItemMapping();
				OrderItemDto orderItem = itemMapping.AddOrderItemMap(item, order.Id);

				var listOrder = mapper.Map<OrderItem>(orderItem);
				orderService.AddOrderItem(listOrder);
				Console.WriteLine("hhh");
				await unitOfWork.Complete();

			}
			return new ResponseDto
			{
				IsSuccess = true,
				Message = "Order successfully",
			};
		}
		return NoContent();
	}

	[HttpGet("purchase")]
	public async Task<IActionResult> GetOrdersOfAccount(string token)
	{
		var orders = await orderService.GetPurchase(token);
		if (orders == null)
		{
			return NoContent();
		}
		return Ok(orders);
	}
}
