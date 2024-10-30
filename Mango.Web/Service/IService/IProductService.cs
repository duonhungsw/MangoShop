using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductsAsync(string? search, string? sort, string? brand, string? type, int pageNumber = 1, int pageSize = 8);
        Task<ResponseDto?> GetProductByIdAsync(Guid id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductsAsync(AccountDto productDto);
        Task<ResponseDto?> DeleteProductsAsync(Guid id);
    }
}
