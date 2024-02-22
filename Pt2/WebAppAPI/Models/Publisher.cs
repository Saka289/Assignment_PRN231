using System.ComponentModel.DataAnnotations;

namespace WebAppAPI.Models
{
    public class Publisher
    {
        [Key]
        public int pub_id { get; set; }
        [Required]
        public string publisher_name { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
