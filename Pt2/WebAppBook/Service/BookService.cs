using WebAppBook.Models;
using WebAppBook.Models.Dtos;
using WebAppBook.Service.IService;

namespace WebAppBook.Service
{
    public class BookService : IBookService
    {
        private readonly IBaseService _baseService;

        public BookService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateBook(BookDto bookDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = bookDto,
                Url = SD.BookAPIBase + "/api/Book/CreateBook"
            });
        }

        public async Task<ResponseDto?> DeleteBook(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.BookAPIBase + "/api/Book/" + id
            });
        }

        public async Task<ResponseDto?> GetAllBook()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BookAPIBase + "/api/Book"
            });
        }

        public async Task<ResponseDto?> GetBook(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BookAPIBase + "/api/Book/" + id
            });
        }

        public async Task<ResponseDto?> SearchBook(string text)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BookAPIBase + "/api/Book/SearchBook/" + text
            });
        }

        public async Task<ResponseDto?> UpdateBook(BookDto bookDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = bookDto,
                Url = SD.BookAPIBase + "/api/Book/UpdateBook"
            });
        }
    }
}
