using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Unility;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Service;

public class CartItemService(IBaseService baseService) : ICartItemService
{
	public async Task<ResponseDto?> AddToCartAsync(AddToCartDto addToCartDto)
	{
		return await baseService.SendAsync(new RequestDto()
		{
			ApiType = SD.ApiType.POST,
			Data = addToCartDto,
			Url = SD.ShoppingCartAPIBase + "api/ShoppingCart/add-to-cart" 
		});
	}

	public async Task<ResponseDto?> DeleteCartItemAsync(Guid id)
	{
		return await baseService.SendAsync(new RequestDto()
		{
			ApiType = SD.ApiType.DELETE,
			Data = id,
			Url = SD.ShoppingCartAPIBase + "api/ShoppingCart/delete?id=" + id
		});
	}

	public async Task<ResponseDto?> GetCartByTokenAsync(string token)
	{
		return await baseService.SendAsync(new RequestDto()
		{
			ApiType = SD.ApiType.GET,
			Data = token,
			Url = SD.ShoppingCartAPIBase + "api/ShoppingCart/get-by-token?token=" + token
		});
	}

	public async Task<ResponseDto?> GetCartItemListByIdAsync(Guid id)
	{
		return await baseService.SendAsync(new RequestDto()
		{
			ApiType = SD.ApiType.GET,
			Data = id,
			Url = SD.ShoppingCartAPIBase + "api/ShoppingCart/get-shopping-cart?id=" + id
		});
	}

	public Task<ResponseDto?> GetCartItemListAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<ResponseDto?> UpdateCartItemAsync(CartItemDto cartItemDto)
	{
		return await baseService.SendAsync(new RequestDto()
		{
			ApiType = SD.ApiType.PUT,
			Data = cartItemDto,
			Url = SD.ShoppingCartAPIBase + "api/ShoppingCart/update-cartItem"
		});
	}

	public async Task<ResponseDto?> GetCartItemByIdAsync(Guid id)
	{
		return await baseService.SendAsync(new RequestDto()
		{
			ApiType = SD.ApiType.GET,
			Data = id,
			Url = SD.ShoppingCartAPIBase + "api/ShoppingCart/get-by-id?id=" + id
		});
	}

	public async Task<ResponseDto?> GetCartItemByStatusAsync(Guid id)
	{
		return await baseService.SendAsync(new RequestDto()
		{
			ApiType = SD.ApiType.GET,
			Url = SD.ShoppingCartAPIBase + $"api/ShoppingCart/ListCheckout?id={id}"
		});
	}
}
