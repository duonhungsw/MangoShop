using Mango.Service.OrderAPI.Models.Dto;
using Newtonsoft.Json;

namespace Mango.Service.OrderAPI.Services
{
	public interface ICartService
	{
		Task<IEnumerable<CartItemDto>> GetOrders(Guid id);
	}
	public class CartService : ICartService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CartService(IHttpClientFactory clientFactory)
		{
			_httpClientFactory = clientFactory;
		}
		public async Task<IEnumerable<CartItemDto>?> GetOrders(Guid Id)
		{
			var client = _httpClientFactory.CreateClient("ShoppingCart");
			var response = await client.GetAsync($"api/ShoppingCart/ListCheckout?id={Id}");
			var apiContent = await response.Content.ReadAsStringAsync();
			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
			if (resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<IEnumerable<CartItemDto>>(Convert.ToString(resp.Result));
			}
			return new List<CartItemDto>();
		}

	}
}
