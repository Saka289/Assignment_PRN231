using AutoMapper;
using RepositoryAPI.Models;
using RepositoryAPI.Models.Dto;
using RepositoryAPI.Repository.IRepository;
using ServiceAPI.Service.IService;

namespace ServiceAPI.Service;

public class ServicePriceListService : IServicePriceListService
{
    private readonly IServicePriceListRepository _servicePriceListRepository;
    private readonly IMapper _mapper;

    public ServicePriceListService(IServicePriceListRepository servicePriceListRepository, IMapper mapper)
    {
        _servicePriceListRepository = servicePriceListRepository;
        _mapper = mapper;
    }

    public List<ServicePriceListDto> GetAll()
    {
        try
        {
            var result = _mapper.Map<List<ServicePriceListDto>>(_servicePriceListRepository.GetAll());
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<ServicePriceListDto> SearchByName(string name)
    {
        try
        {
            var result = _mapper.Map<List<ServicePriceListDto>>(_servicePriceListRepository.SearchByName(name));
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ServicePriceListDto GetById(int id)
    {
        try
        {
            var result = _mapper.Map<ServicePriceListDto>(_servicePriceListRepository.GetById(id));
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool Create(ServicePriceListDto servicePriceListDto)
    {
        try
        {
            ServicePriceList model = _mapper.Map<ServicePriceList>(servicePriceListDto);
            _servicePriceListRepository.Create(model);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool Update(ServicePriceListDto servicePriceListDto)
    {
        try
        {
            var result = _servicePriceListRepository.GetById(servicePriceListDto.ServiceId);
            if (result != null)
            {
                ServicePriceList model = _mapper.Map<ServicePriceList>(servicePriceListDto);
                _servicePriceListRepository.Update(model);
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

        return false;
    }

    public bool Delete(int id)
    {
        try
        {
            var result = _servicePriceListRepository.GetById(id);
            if (result != null)
            {
                _servicePriceListRepository.Delete(id);
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

        return false;
    }
}