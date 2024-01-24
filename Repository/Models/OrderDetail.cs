using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Money { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
