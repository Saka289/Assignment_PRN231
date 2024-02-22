using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAPI.Models
{
    public class BookAuthor
    {
        [Key]
        public int author_id { get; set; }
        [Key]
        public int book_id { get; set; }
        [Required]
        public string author_order { get; set; }
        public int royality_percentage { get; set; }

        [ForeignKey(nameof(book_id))]
        public Book Book { get; set; }

        [ForeignKey(nameof(author_id))]
        public Author Author { get; set; }
    }
}
