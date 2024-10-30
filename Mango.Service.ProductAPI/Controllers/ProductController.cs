using AutoMapper;
using Book.Core.Interfaces;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dtos;
using Mango.Service.ProductAPI.Repository;
using Mango.Service.ProductAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Service.ProductAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IUnitOfWork unitOfWork,
	IProductRepository productRepository,
	IProductService productService,
	IImageService imageService,
	IMapper mapper) : ControllerBase
{
	[HttpGet("ListProducts")]
	public async Task<ActionResult<IEnumerable<Product>>> ListProduct(
		[FromQuery] string? search = null,
		[FromQuery] string? sort = null,
		[FromQuery] string? brand = null,
		[FromQuery] string? type = null,
		[FromQuery] int pageNumber = 1,
		[FromQuery] int pageSize = 8)
	{
		var products = await productService.GetAllAsync(search, sort, brand, type, pageNumber, pageSize);
		return Ok(new ResponseDto
		{
			IsSuccess = true,
			Message = "Load list product successfully",
			Result = products
		});
	}
	[HttpGet("Products")]
	public async Task<ActionResult<IEnumerable<Product>>> ListProduct()
	{
		var products = await productService.GetAllAsync();
		if (products == null) return NoContent();
		return Ok(new ResponseDto
		{
			IsSuccess = true,
			Message = "Produc list",
			Result = products
		});
	}

	[HttpGet("get-by-id")]
	public async Task<ActionResult<Product>?> GetProductById(Guid id)
	{
		var product = await productService.GetByIdAsync(id);
		if (product == null)
		{
			return NotFound(new ResponseDto
			{
				IsSuccess = false,
				Message = "Product not found"
			});
		}
		return Ok(new ResponseDto
		{
			IsSuccess = true,
			Message = "Get product successfully",
			Result = product
		});
	}

	[HttpPost("add-product")]
	public async Task<ActionResult<ResponseDto>> AddProduct([FromForm] ProductDto productDto,  IFormFile file)
	{
		var pictureUrl = await imageService.UpLoadFile(file);
		productDto.PictureUrl = pictureUrl;
		var productModel =  mapper.Map<Product>(productDto);
		productService.Create(productModel);
		if(await unitOfWork.Complete())
		{
			return new ResponseDto
			{
				IsSuccess = true,
				Message = "Add product successfully",
				Result = productModel
			};
		}
		return new ResponseDto
		{
			IsSuccess = true,
			Message = "Add product successfully",
		};
	}

}
