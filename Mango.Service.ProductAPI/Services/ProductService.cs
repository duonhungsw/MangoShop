using Book.Core.Interfaces;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Repository;
using Mango.Service.ProductAPI.RequestHelper;

namespace Mango.Service.ProductAPI.Services;

public interface IProductService
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<PagedResult<Product>> GetAllAsync(string? search, string? sort, string? brand, string? type, int pageNumber = 1, int pageSize = 8);
    void Delete(Product entity);
    void Update(Product entity);
    void Create(Product entity);
    bool Exist(Guid id);

}
public class ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository) : IProductService
{
    public void Create(Product entity) => unitOfWork.Repository<Product>().Create(entity);
    public void Delete(Product entity) => unitOfWork.Repository<Product>().Delete(entity);
    public bool Exist(Guid id) => unitOfWork.Repository<Product>().Exist(id);
    public Task<IEnumerable<Product>> GetAllAsync()
        => productRepository.ListAsync();
    public async Task<Product?> GetByIdAsync(Guid id) => await unitOfWork.Repository<Product>().GetByIdAsync(id);
    public void Update(Product entity) => unitOfWork.Repository<Product>().Update(entity);
    public async Task<PagedResult<Product>> GetAllAsync(string? search, string? sort, string? brand, string? type, int pageNumber = 1, int pageSize = 8)
    {
        var query = productRepository.ListAsQueryAsync();

        //Search
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Name.Contains(search));
        }

        //brand
        //if (brand != null)
        //{
        //    query = query.Where(x => x.Brand == brand);
        //}
        //type
        //if (type != null)
        //{
        //    query = query.Where(x => x.Type == type);
        //}

        //Sorting
        //if (!string.IsNullOrWhiteSpace(sort))
        //{
        //switch (sort)
        //{
        //    case "price_desc":
        //        query.OrderByDescending(x => x.Price);
        //        break;
        //    case "price_asc":
        //        query.OrderBy(x => x.Price);
        //        break;
        //    case "name_desc":
        //        query.OrderByDescending(x => x.Price);
        //        break;
        //    default:
        //        query.OrderBy(x => x.Name);
        //        break;
        //}
        if (!string.IsNullOrWhiteSpace(sort))
        {
            query = sort switch
            {
                "price_desc" => query.OrderByDescending(x => x.Price),
                "price_asc" => query.OrderBy(x => x.Price),
                "name_desc" => query.OrderByDescending(x => x.Name),
                _ => query.OrderBy(x => x.Name)
            };
        }
        //}
        var totalItems = query.Count();
        var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        var products = await productRepository.PaginationAsync(pageNumber, pageSize);

        var pageNumbers = GetPageNumbers(pageNumber, totalPages);

        return new PagedResult<Product>
        {
            CurrentPage = pageNumber,
            TotalPages = totalPages,
            Items = products,
            PageNumbers = pageNumbers
        };
    }

    private List<int> GetPageNumbers(int currentPage, int totalPages)
    {
        int startPage = Math.Max(1, currentPage - 2);
        int endPage = Math.Min(totalPages, currentPage + 2);

        var pages = new List<int>();

        if (startPage > 1)
        {
            pages.Add(1); // Trang đầu tiên
            if (startPage > 2)
            {
                pages.Add(-1); // Dấu "..." giữa trang 1 và trang startPage
            }
        }

        for (int i = startPage; i <= endPage; i++)
        {
            pages.Add(i);
        }

        if (endPage < totalPages)
        {
            if (endPage < totalPages - 1)
            {
                pages.Add(-1); // Dấu "..." giữa endPage và trang cuối cùng
            }
            pages.Add(totalPages); // Trang cuối cùng
        }

        return pages;
    }
}
