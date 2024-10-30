﻿namespace Mango.Service.ProductAPI.Models.Dtos;

public class ProductDto
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public decimal Price { get; set; }
	public string? PictureUrl { get; set; }
	public string? Type { get; set; }
	public string? Brand { get; set; }
	public int QuantityInStock { get; set; }
}
