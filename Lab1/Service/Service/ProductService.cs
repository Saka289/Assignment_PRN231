using Repository.Models;
using Repository.Repository.IRepository;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProduct()
        {
            try
            {
                var result = _productRepository.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                List<Product> products = _productRepository.GetAll();
                var result = products.Where(p => p.UnitInStock < 3).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }
    }
}
