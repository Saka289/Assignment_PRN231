using WebAppBook.Models;
using WebAppBook.Models.Dtos;

namespace WebAppBook.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
