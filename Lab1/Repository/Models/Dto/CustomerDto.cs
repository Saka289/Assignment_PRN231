using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Dto
{
    public class CustomerDto
    {
        public string CustomerId { get; set; } = null!;
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? DiscountRate { get; set; }
    }
}
