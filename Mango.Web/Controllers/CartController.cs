using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers;
public class CartController(ICartItemService cartItemService, ITokenProvider tokenProvider) : Controller
{
	[HttpGet]
	public async Task<IActionResult> ShoppingCart()
	{
		string? token = tokenProvider.GetToken();
		if (token != null)
		{
			ResponseDto? responseDto = await cartItemService.GetCartByTokenAsync(token);
			if (responseDto != null && responseDto.IsSuccess)
			{
				CartDto? cart = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(responseDto.Result));
				ResponseDto? responseDto1 = await cartItemService.GetCartItemListByIdAsync(cart.Id);
				if (responseDto1 != null && responseDto1.IsSuccess) 
				{
					List<CartItemDto>? items = JsonConvert.DeserializeObject<List<CartItemDto>>(Convert.ToString(responseDto1.Result));
					return View(items);
				}
			}
			else
			{
				TempData["notFound"] = responseDto?.Message;
				return View("Index", "Home");
			}
		}
		return RedirectToAction("Login", "Account");

	}
	[HttpPost]
	public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
	{
		string? hasToken = tokenProvider.GetToken();

		if (hasToken != null)
		{
			addToCartDto.Token = hasToken;
			ResponseDto? responseDto = await cartItemService.AddToCartAsync(addToCartDto);
			try
			{
				if (responseDto != null && responseDto.IsSuccess)
				{
					return Json(new { success = true, message = "Add to cart successfully." });
				}
				else
				{
					return Json(new { success = false, message = responseDto?.Message });
				}
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = "Have error: " + ex.Message });
			}
		}
		return Json(new { success = false, message = "Account don't login" });
	}
	[HttpDelete("Cart/DeleteCartItem/{id}")]
	public async Task<IActionResult> DeleteCartItem(string id)
	{
		ResponseDto? responseDto = await cartItemService.DeleteCartItemAsync(Guid.Parse(id));
		if (responseDto != null && responseDto.IsSuccess)
		{
			return Json(new { success = true, message = "Delete cart item successfully." });
		}
		else
		{
			return Json(new { success = false, message = responseDto?.Message });
		}
	}

	[HttpPut]
	public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDto updateCartItemDto)
	{
		ResponseDto? response = await cartItemService.GetCartItemByIdAsync(Guid.Parse(updateCartItemDto.id));
		if (response == null && !response.IsSuccess)
		{
			return Json(new { success = false, message = response?.Message });
		}
		
		var cartItem =  JsonConvert.DeserializeObject<CartItemDto>(Convert.ToString(response.Result));
		CartItemDto cartItemDto = new CartItemDto()
		{
			Id = cartItem.Id,
			CartId = cartItem.CartId,
			ProductId = cartItem.ProductId,
			Price = cartItem.Price,
			Quantity = cartItem.Quantity,
			Status = updateCartItemDto.Status,
			Total_money = cartItem.Total_money,
		};

		ResponseDto? responseDto = await cartItemService.UpdateCartItemAsync(cartItemDto);
		if (responseDto != null && responseDto.IsSuccess)
		{
			return Json(new { success = true, message = "Delete cart item successfully." });
		}
		else
		{
			return Json(new { success = false, message = responseDto?.Message });
		}
	}

}
