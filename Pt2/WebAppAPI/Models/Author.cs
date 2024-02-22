using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppAPI.Models
{
    public class Author
    {
        [Key]
        public int author_id { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }

        [Required]
        public string zip { get; set; }

        [Required]
        public string email_address { get; set; }

        public IEnumerable<BookAuthor> BookAuthors { get; set; }
    }
}
