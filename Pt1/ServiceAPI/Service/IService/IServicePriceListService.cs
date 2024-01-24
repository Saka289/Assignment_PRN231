using RepositoryAPI.Models;
using RepositoryAPI.Models.Dto;

namespace ServiceAPI.Service.IService;

public interface IServicePriceListService
{
    public List<ServicePriceListDto> GetAll();

    public List<ServicePriceListDto> SearchByName(string name);

    public ServicePriceListDto GetById(int id);

    public bool Create(ServicePriceListDto servicePriceListDto);

    public bool Update(ServicePriceListDto servicePriceListDto);

    public bool Delete(int id);
}