using AutoMapper;
using WebAppAPI.Models;
using WebAppAPI.Models.Dtos;

namespace WebAppAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<BookDto, Book>().ReverseMap();
            config.CreateMap<PubDto, Publisher>().ReverseMap();
        });
        return mappingConfig;
    }
}