using AutoMapper;
using RepositoryAPI.Models;
using RepositoryAPI.Models.Dto;

namespace WebAppAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<MedicalFacility, MedicalFacilityDto>().ReverseMap();
            config.CreateMap<ServicePriceList, ServicePriceListDto>().ReverseMap();
        });
        return mappingConfig;
    }
}