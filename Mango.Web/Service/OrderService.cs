using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Unility;

namespace Mango.Web.Service
{
	public class OrderService(IBaseService baseService) : IOrderService
	{
		public async Task<ResponseDto?> CreateOrderAsync(OrderDto orderDto)
		{
			return await baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = orderDto,
				Url = SD.OrderAPIBase + "api/Order/Order"
			});
		}

		public Task<ResponseDto?> GetAllCouponsAsync()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseDto?> GetOrderByIdAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
