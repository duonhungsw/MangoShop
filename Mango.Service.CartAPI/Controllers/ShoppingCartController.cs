using AutoMapper;
using Book.Core.Interfaces;
using Common.Extensions;
using Mango.Service.CartAPI.Mapppings;
using Mango.Service.CartAPI.Models;
using Mango.Service.CartAPI.Models.Dto;
using Mango.Service.CartAPI.Services;
using Mango.Service.CartItemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mango.Service.CartAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController(IUnitOfWork unitOfWork,
							ICartService cartService,
							ICartItemService cartItemService,
							IProductService productService,
							IMapper mapper,
							IHttpContextAccessor _contextAccessor) : ControllerBase
{

	[HttpGet("get-by-token")]
	public async Task<ActionResult<ResponseDto>> GetById(string token)
	{
		if (token != null)
		{
			var handler = new JwtSecurityTokenHandler();
			var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
			if (jsonToken == null)
			{
				return Unauthorized(new { message = "Token is invalid." });
			}

			var claims = jsonToken.Claims;
			var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
			var accountId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(accountId))
			{
				return Unauthorized(new { message = "Invalid token data." });
			}

			if (accountId != null)
			{
				var cart = await cartService.GetCartByAccountIdAsync(Guid.Parse(accountId));
				if (cart == null)
				{
					try
					{
						Cart cartNew = new Cart()
						{
							Id = new Guid(),
							AccountId = Guid.Parse(accountId),
						};
						cartService.CreateCart(cartNew);
						if (await unitOfWork.Complete())
						{
							return Ok(new ResponseDto
							{
								IsSuccess = true,
								Message = "Cart info of Account",
								Result = cartNew
							});
						}
					}
					catch (Exception ex)
					{
						return BadRequest(ex.Message);
					}
				}
				return Ok(new ResponseDto()
				{
					IsSuccess = true,
					Message = "Cart ID",
					Result = cart
				});
			}
			return BadRequest("Not found cart of user");
		}
		return BadRequest("Not found token");
	}
	[HttpGet("get-shopping-cart")]
	public async Task<ActionResult<ResponseDto>> GetShoppingCartByCartId(Guid Id)
	{
		try
		{
			var shoppingCarts = await cartItemService.GetShoppingCartByCartIdAsync(Id);
			IEnumerable<ProductDto> productDtos = await productService.GetProducts();
			if (productDtos == null) return NoContent();

			foreach (var item in shoppingCarts)
			{
				item.ProductDto = productDtos.FirstOrDefault(x => x.Id == item.ProductId);
			}
			return new ResponseDto()
			{
				IsSuccess = true,
				Message = "List shopping cart",
				Result = shoppingCarts
			};
		}
		catch (Exception ex)
		{
			return new ResponseDto()
			{
				IsSuccess = false,
				Message = "Not found item in Cart"
			};
		}
	}

	[HttpPost("add-to-cart")]
	public async Task<ActionResult<ResponseDto>> AddToCart(AddToCartDto addToCartDto)
	{
		try
		{
			var accountId = JwtExtension.GetToken(addToCartDto.Token);
			if (accountId == null)
			{
				return NoContent(); 
			}
			var cartExist = await cartService.GetCartByAccountIdAsync(Guid.Parse(accountId));
			if (cartExist == null)
			{
				return NotFound(new ResponseDto
				{
					IsSuccess = false,
					Message = "Cart not found"
				});
			}

			var productExist = await cartItemService.GetByProductIdAsync(addToCartDto.ProductId, cartExist.Id);

			if (productExist == null)
			{
				CartItemMapping mapping = new CartItemMapping();
				var cartItemDto = mapping.CreateCartItemDto(addToCartDto, cartExist.Id);
				var cartItem = mapper.Map<CartItem>(cartItemDto);
				cartItemService.AddToCart(cartItem);
			}
			else
			{
				productExist.Quantity += addToCartDto.Quantity;
				productExist.Total_money += addToCartDto.Price * addToCartDto.Quantity;

				cartItemService.UpdateCartItem(productExist);
			}

			if (await unitOfWork.Complete())
			{
				return Ok(new ResponseDto
				{
					IsSuccess = true,
					Message = "Add to cart success"
				});
			}
			else
			{
				return BadRequest(new ResponseDto
				{
					IsSuccess = false,
					Message = "Failed to add/update cart item"
				});
			}
		}
		catch (Exception ex)
		{
			return BadRequest(new ResponseDto
			{
				IsSuccess = false,
				Message = $"Error: {ex.Message}"
			});
		}
	}
	[HttpPut("update-cartItem")]
	public async Task<IActionResult> UpdateItem(CartItemDto cartItemDto)
	{
		var cartItem = mapper.Map<CartItem>(cartItemDto);
		cartItemService.UpdateCartItem(cartItem);
		if (await unitOfWork.Complete())
		{
			return Ok(cartItem);
		}
		return BadRequest();
	}
	[HttpDelete("delete")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var cartItem = await cartItemService.GetByIdAsync(id);

		cartItemService.Delete(cartItem);
		if (await unitOfWork.Complete())
		{
			return Ok(cartItem);
		}
		return BadRequest();
	}
	[HttpGet("get-by-id")]
	public async Task<ActionResult<ResponseDto>> GetById(Guid id)
	{
		var cartItem = await cartItemService.GetByIdAsync(id);
		if (cartItem == null) return NoContent();
		return new ResponseDto()
		{
			IsSuccess = true,
			Message = "List shopping cart",
			Result = cartItem
		};
	}

	[HttpGet("ListCheckout")]
	public async Task<ActionResult<ResponseDto>> ListCheckout(Guid id)
	{
		var cart = await cartService.GetCartByAccountIdAsync(id);

		var lists = await cartItemService.GetOrderAsync(cart.Id);
        foreach (var item in lists)
        {
			item.ProductDto = await productService.GetProductById(item.ProductId);
        }
        if (lists == null) return NoContent();
		return new ResponseDto()
		{
			IsSuccess = true,
			Message = "List checkout",
			Result = lists
		};
	}

}
