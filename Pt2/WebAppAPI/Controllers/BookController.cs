using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models.Dtos;
using WebAppAPI.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        protected ResponseDto _response;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ActionResult<ResponseDto> GetAllBooks()
        {
            try
            {
                IEnumerable<BookDto> objList = _repository.GetAllBooks();
                _response.Result = objList;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseDto> GetBook(int id)
        {
            try
            {
                var result = _repository.GetBook(id);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost("CreateBook")]
        public ActionResult<ResponseDto> CreateBook([FromBody] BookDto model)
        {
            try
            {
                var result = _repository.CreateBook(model);
                _response.Message = "Create Book Successfully !!!";
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut("UpdateBook")]
        public ActionResult<ResponseDto> UpdateBook([FromBody] BookDto model)
        {
            try
            {
                var result = _repository.UpdateBook(model);
                _response.Message = "Update Book Successfully !!!";
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("SearchBook/{text}")]
        public ActionResult<ResponseDto> SearchBook(string text)
        {
            try
            {
                var result = _repository.SearchBook(text);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public ActionResult<ResponseDto> DeleteBook(int id)
        {
            try
            {
                var result = _repository.DeleteBook(id);
                _response.Message = "Delete Book Successfully !!!";
                _response.Result = result;
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
