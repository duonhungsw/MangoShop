using AutoMapper;
using Mango.Service.OrderAPI.Models;
using Mango.Service.OrderAPI.Models.Dto;

namespace Mango.Service.OrderAPI.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<OrderDto, Order>().ReverseMap();
			CreateMap<OrderItemDto, OrderItem>().ReverseMap();
		}
	}
}
