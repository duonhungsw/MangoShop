using Mango.Service.CartAPI.Models.Dto;

namespace Mango.Service.CartAPI.Mapppings
{
    public class CartItemMapping
    {
        public CartItemDto CreateCartItemDto( AddToCartDto addToCartDto, Guid cartId)
        {
            return new CartItemDto
            {
                Id = Guid.NewGuid(),
                CartId = cartId,
                ProductId = addToCartDto.ProductId,
                Quantity = addToCartDto.Quantity,
                Price = addToCartDto.Price,
                Total_money = addToCartDto.Price * addToCartDto.Quantity,
                Status = false
            };
        }
    }
}
