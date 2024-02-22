using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAPI.Models.Dtos;
using WebAppAPI.Repository;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubController : ControllerBase
    {
        private readonly IPubRepository _repository;
        protected ResponseDto _response;

        public PubController(IPubRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ActionResult<ResponseDto> GetAllPubs()
        {
            try
            {
                IEnumerable<PubDto> objList = _repository.GetAllPubs();
                _response.Result = objList;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
