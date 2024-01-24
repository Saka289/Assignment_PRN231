using RepositoryAPI.Data;
using RepositoryAPI.Models;
using RepositoryAPI.Repository.IRepository;

namespace RepositoryAPI.Repository;

public class ServicePriceListRepository : IServicePriceListRepository
{
    private readonly AppDbContext _context;

    public ServicePriceListRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<ServicePriceList> GetAll()
    {
        return _context.ServicePriceLists.ToList();
    }

    public List<ServicePriceList> SearchByName(string name)
    {
        return _context.ServicePriceLists.Where(s => s.ServiceName == name).ToList();
    }

    public ServicePriceList GetById(int id)
    {
        var obj = _context.ServicePriceLists.FirstOrDefault(s => s.ServiceId == id);
        if (obj != null)
        {
            return obj;
        }

        return null;
    }

    public void Create(ServicePriceList servicePriceList)
    {
        _context.ServicePriceLists.Add(servicePriceList);
        _context.SaveChanges();
    }

    public void Update(ServicePriceList servicePriceList)
    {
        var obj = _context.ServicePriceLists.FirstOrDefault(s => s.ServiceId == servicePriceList.ServiceId);
        if (obj != null)
        {
            obj.ServiceName = servicePriceList.ServiceName;
            obj.ServicePrice = servicePriceList.ServicePrice;
            obj.ServiceLevel = servicePriceList.ServiceLevel;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var obj = _context.ServicePriceLists.FirstOrDefault(s => s.ServiceId == id);
        if (obj != null)
        {
            _context.ServicePriceLists.Remove(obj);
            _context.SaveChanges();
        }
    }
}