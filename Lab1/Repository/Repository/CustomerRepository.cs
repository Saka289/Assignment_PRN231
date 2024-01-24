using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MVVMContext _context;

        public CustomerRepository(MVVMContext context)
        {
            _context = context;
        }

        public bool DeleteOrder(string id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order != null)
            {
                var orderDetail = _context.OrderDetails.Where(o => o.OrderId == order.OrderId).ToList();
                _context.OrderDetails.RemoveRange(orderDetail);
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer UpdateDiscount(string cusomterId, int discount)
        {
            var result = _context.Customers.First(c => c.CustomerId == cusomterId);
            if (result != null)
            {
                result.DiscountRate = discount;
                _context.SaveChanges();
                return result;
            }
            return new Customer();
        }
    }
}
