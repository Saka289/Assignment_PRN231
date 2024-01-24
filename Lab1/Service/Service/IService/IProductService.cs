using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IProductService
    {
        List<Product> GetAllProduct();

        List<Product> GetProducts();
    }
}
