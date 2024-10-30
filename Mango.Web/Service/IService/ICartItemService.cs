using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
	public interface ICartItemService
	{
		Task<ResponseDto?> GetCartItemListAsync();
		Task<ResponseDto?> GetCartItemListByIdAsync(Guid id);
		Task<ResponseDto?> GetCartItemByIdAsync(Guid id);
		Task<ResponseDto?> GetCartItemByStatusAsync(Guid id);
		Task<ResponseDto?> AddToCartAsync(AddToCartDto addToCartDto);
		Task<ResponseDto?> UpdateCartItemAsync(CartItemDto cartItemDto);
		Task<ResponseDto?> DeleteCartItemAsync(Guid id);
		Task<ResponseDto?> GetCartByTokenAsync(string token);
	}
}
