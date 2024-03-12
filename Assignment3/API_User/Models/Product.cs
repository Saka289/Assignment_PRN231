using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_User.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int UnitInStock { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
