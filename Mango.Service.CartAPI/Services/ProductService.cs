using Mango.Service.CartAPI.Models.Dto;
using Newtonsoft.Json;

namespace Mango.Service.CartAPI.Services
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDto>> GetProducts();
		Task<ProductDto?> GetProductById(Guid id);
	}
	public class ProductService : IProductService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductService(IHttpClientFactory clientFactory)
		{
			_httpClientFactory = clientFactory;
		}
		public async Task<IEnumerable<ProductDto>> GetProducts()
		{
			var client = _httpClientFactory.CreateClient("Product");
			var response = await client.GetAsync($"/api/product/Products");
			var apiContent = await response.Content.ReadAsStringAsync();
			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
			if (resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
			}
			return new List<ProductDto>();
		}
		public async Task<ProductDto?> GetProductById(Guid id)
		{
			var client = _httpClientFactory.CreateClient("Product");
			var response = await client.GetAsync($"/api/product/get-by-id?id="+id);
			var apiContent = await response.Content.ReadAsStringAsync();
			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
			if (resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(resp.Result));
			}
			return new ProductDto();
		}
	}
}
