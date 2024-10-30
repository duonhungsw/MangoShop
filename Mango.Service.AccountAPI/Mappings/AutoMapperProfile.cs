using AutoMapper;
using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Models.Dto;

namespace Mango.Service.AccountAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.RoleViewModel, opt => opt.MapFrom(src => src.Role)).ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}
