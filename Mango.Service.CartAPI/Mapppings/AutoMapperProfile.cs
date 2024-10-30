using AutoMapper;
using Mango.Service.CartAPI.Models;
using Mango.Service.CartAPI.Models.Dto;

namespace Mango.Service.CartAPI.Mapppings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CartItemDto, CartItem>().ReverseMap();
        }
    }
}
