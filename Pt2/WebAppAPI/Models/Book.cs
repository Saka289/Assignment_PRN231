using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAPI.Models
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int pub_id { get; set; }
        public decimal price { get; set; }
        public string advance { get; set; }
        public string royalty { get; set; }
        public string ytd_sales { get; set; }
        public string note { get; set; }

        public DateTime published_date { get; set; }
        [ForeignKey(nameof(pub_id))]
        public Publisher Publisher { get; set; }

        public IEnumerable<BookAuthor> BookAuthors { get; set; }
    }
}
