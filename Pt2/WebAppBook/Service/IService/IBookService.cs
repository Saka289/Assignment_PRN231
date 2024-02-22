using WebAppBook.Models;
using WebAppBook.Models.Dtos;

namespace WebAppBook.Service.IService
{
    public interface IBookService
    {
        Task<ResponseDto?> GetAllBook();
        Task<ResponseDto?> GetBook(int id);
        Task<ResponseDto?> SearchBook(string text);
        Task<ResponseDto?> CreateBook(BookDto bookDto);
        Task<ResponseDto?> UpdateBook(BookDto bookDto);
        Task<ResponseDto?> DeleteBook(int id);
    }
}
