using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();

        bool DeleteOrder(string id);

        Customer UpdateDiscount(string cusomterId, int discount);
    }
}
