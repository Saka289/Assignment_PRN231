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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly MVVMContext _context;
        public CustomerService(ICustomerRepository customerRepository, MVVMContext context)
        {
            _customerRepository = customerRepository;
            _context = context;
        }

        public bool DeleteOrder(string id)
        {
            try
            {
                var result = _customerRepository.DeleteOrder(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Customer> GetAllCustomer()
        {
            try
            {
                var result = _customerRepository.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }

        }

        public List<Customer> GetCustomer()
        {
            try
            {
                List<Customer> customers = _customerRepository.GetAll();
                var result = customers.Where(c => c.DiscountRate > 30).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }

        public List<Customer> GetOrder()
        {
            try
            {
                List<Customer> customers = _context.Customers.Where(o => o.Orders.Count >= 2).ToList();
                return customers;
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }

        }

        public Customer UpdateDiscount(string cusomterId, int discount)
        {
            try
            {
                return _customerRepository.UpdateDiscount(cusomterId, discount);
            }
            catch (Exception ex)
            {
                return new Customer();
            }
        }
    }
}
