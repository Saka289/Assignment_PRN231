using WebAppBook.Models;

namespace WebAppBook.Service.IService
{
    public interface IPubService
    {
        Task<ResponseDto?> GetAllPub();
    }
}
