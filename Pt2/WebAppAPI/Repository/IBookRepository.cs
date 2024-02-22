using WebAppAPI.Models;
using WebAppAPI.Models.Dtos;

namespace WebAppAPI.Repository
{
    public interface IBookRepository
    {
        IEnumerable<BookDto> GetAllBooks();
        BookDto GetBook(int id);
        bool CreateBook(BookDto bookDto);
        bool UpdateBook(BookDto bookDto);
        bool DeleteBook(int id);

        IEnumerable<BookDto> SearchBook(string text);
    }
}
