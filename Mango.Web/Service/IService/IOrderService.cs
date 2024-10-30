using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
	public interface IOrderService
	{
		Task<ResponseDto?> GetAllCouponsAsync();
		Task<ResponseDto?> GetOrderByIdAsync(int id);
		Task<ResponseDto?> CreateOrderAsync(OrderDto orderDto);
	}
}
