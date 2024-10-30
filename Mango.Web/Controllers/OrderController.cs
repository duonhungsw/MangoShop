using Common.Extensions;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
	public class OrderController(ICartItemService cartItemService,
								IOrderService orderService,
								ITokenProvider tokenProvider) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Checkout()
		{
			string? token = tokenProvider.GetToken();
			if (token == null)
			{
				View("Index", "Home");
			}
			ResponseDto? response = await cartItemService.GetCartItemByStatusAsync(Guid.Parse(JwtExtension.GetToken(token)));
			if (response == null)
			{
				return View();
			}
			IEnumerable<CartItemDto> cartItems = JsonConvert.DeserializeObject<IEnumerable<CartItemDto>>(Convert.ToString(response.Result));
			return View(cartItems);
		}
		[HttpPost]
		public async Task<IActionResult> Order(OrderDto orderDto)
		{
			string? token = tokenProvider.GetToken();
			if (token == null) 
			{
				View("Index", "Home");
			}
			orderDto.AccountId = Guid.Parse(JwtExtension.GetToken(token));
			ResponseDto? response = await orderService.CreateOrderAsync(orderDto);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction("Thankyou", "Home");
			}
			return View("Index", "Home");
		}
	}



}
