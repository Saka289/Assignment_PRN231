using AutoMapper;
using Repository.Models;
using Repository.Models.Dto;

namespace WebApp
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CustomerDto, Customer>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
