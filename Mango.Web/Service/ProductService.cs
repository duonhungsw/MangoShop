using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Unility;

namespace Mango.Web.Service
{
    public class ProductService(IBaseService baseService) : IProductService
    {

        public Task<ResponseDto?> CreateProductsAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteProductsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllProductsAsync(string? search, string? sort, string? brand, string? type,
                                    int pageNumber = 1, int pageSize = 8)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Data =new
                {
                    search, sort, brand, type, pageNumber, pageSize
                },
                Url = SD.ProductAPIBase + $"api/Product/ListProducts?search={search}&sort={sort}&brand={brand}&type={type}&pageNumber=1&pageSize=8"
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(Guid id)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.ProductAPIBase + "api/Product/get-by-id?id=" + id
            });
        }
        public Task<ResponseDto?> UpdateProductsAsync(AccountDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
