namespace Mango.Service.ProductAPI.RequestHelper
{
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }
        public List<int> PageNumbers { get; set; } 
    }
}
