namespace Mango.Web.Models
{
    public class ProductPaginationDto
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<ProductDto>? Items { get; set; }
        public List<int>? PageNumbers { get; set; }
    }
}
