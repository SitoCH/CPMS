using AutoMapper;
using CPMS.Common.Entities;
using CPMS.Web.Dtos;

namespace CPMS.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}