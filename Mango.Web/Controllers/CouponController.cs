using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Mango.Web.Controllers
{
    public class CouponController(ICouponService couponService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult?> ListCoupon() 
        {
            List<CouponDto> list = new();
            ResponseDto responseDto  = await couponService.GetAllCouponsAsync();

            if (responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return View(list);
        }
    }
}
