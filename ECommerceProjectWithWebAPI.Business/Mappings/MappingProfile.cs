using AutoMapper;
using ECommerceProjectWithWebAPI.Entities.Concrete;
using ECommerceProjectWithWebAPI.Entities.Dtos.User;

namespace ECommerceProjectWithWebAPI.Business.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetailDto, User>();
            CreateMap<User, UserDetailDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<UserAddDto, User>();
            CreateMap<User, UserAddDto>();

            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
        }
    }
}
