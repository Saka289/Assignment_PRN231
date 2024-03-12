using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_User.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public ApplicationUser User { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime RequiredDate { get; set; }
        [Required]
        public DateTime ShippedDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Freight { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
