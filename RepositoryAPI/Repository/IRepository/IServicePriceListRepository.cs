using RepositoryAPI.Models;

namespace RepositoryAPI.Repository.IRepository;

public interface IServicePriceListRepository
{
    public List<ServicePriceList> GetAll();

    public List<ServicePriceList> SearchByName(string name);

    public ServicePriceList GetById(int id);

    public void Create(ServicePriceList servicePriceList);

    public void Update(ServicePriceList servicePriceList);

    public void Delete(int id);
}