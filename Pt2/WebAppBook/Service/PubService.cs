using WebAppBook.Models;
using WebAppBook.Models.Dtos;
using WebAppBook.Service.IService;

namespace WebAppBook.Service
{
    public class PubService : IPubService
    {
        private readonly IBaseService _baseService;

        public PubService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> GetAllPub()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BookAPIBase + "/api/Pub/"
            });
        }
    }
}
