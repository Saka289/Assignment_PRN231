using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        List<Customer> GetCustomer();
        List<Customer> GetOrder();
        bool DeleteOrder(string id);
        Customer UpdateDiscount(string cusomterId, int discount);
    }
}
