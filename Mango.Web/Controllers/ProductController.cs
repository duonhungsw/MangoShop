using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController(IProductService productService) : Controller
    {
        public async Task<ActionResult<ProductDto>> ProductIndex(string? search, string? sort, string? brand,
                                        string? type, int pageNumber = 1, int pageSize = 8)
        {
            try
            {
				ProductPaginationDto? productPagination = null;
				ResponseDto? responseDto = await productService.GetAllProductsAsync(search, sort, brand,
											 type, pageNumber, pageSize);
				if (responseDto != null && responseDto.IsSuccess && responseDto != null)
				{
					productPagination = JsonConvert.DeserializeObject<ProductPaginationDto>(Convert.ToString(responseDto.Result));
                    List<ProductDto>? products = productPagination.Items;
                    return View(products);
				}
					TempData["error"] = responseDto?.Message;
                return View();
			}
            catch (Exception ex)
            {
                return View(ex);
            }
            
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
		[HttpGet("{id}")]
		public async Task<IActionResult> ProductDetail(Guid id)
        {
            ProductDto? product = null;
            ResponseDto? responseDto = await productService.GetProductByIdAsync(id);
            if (responseDto != null && responseDto.IsSuccess)
            {
                product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
				return View(product);
			}
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return NoContent();
        }
        
    }
}
