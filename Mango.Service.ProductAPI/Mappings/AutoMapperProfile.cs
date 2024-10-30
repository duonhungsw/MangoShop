using AutoMapper;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dtos;

namespace Mango.Service.ProductAPI.Mappings;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<ProductDto, Product>().ReverseMap();
	}
}
