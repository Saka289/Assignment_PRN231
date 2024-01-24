using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string OrderId { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string? CustomerId { get; set; }
        public decimal? TotalPayment { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
