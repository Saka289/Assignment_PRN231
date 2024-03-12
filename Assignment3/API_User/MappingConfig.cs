using API_User.Models;
using API_User.Models.Dtos;
using AutoMapper;

namespace API_User
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ApplicationUser, UserDto>().ReverseMap();
                config.CreateMap<ApplicationUser, UserAddEditDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
