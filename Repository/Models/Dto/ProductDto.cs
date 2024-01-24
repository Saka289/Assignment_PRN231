using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Dto
{
    public class ProductDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }

    }
}
