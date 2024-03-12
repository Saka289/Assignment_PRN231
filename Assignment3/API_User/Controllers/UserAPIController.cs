using API_User.Models.Dtos;
using API_User.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserAPIController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsers();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetUserByUserID/{userId}")]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserByUserID([Required] string userId)
        {
            var result = await _userService.GetUserByUserId(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetUserByEmail/{email}")]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserByEmail([Required] string email)
        {
            var result = await _userService.GetUserByEmail(email);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser([FromBody] UserAddEditDto model)
        {
            var result = await _userService.CreateUser(model);
            if (result.IsSuccess == true || Convert.ToBoolean(result.Result))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UserAddEditDto model)
        {
            var result = await _userService.UpdateUser(model);
            if (result.IsSuccess == true || Convert.ToBoolean(result.Result))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateRole")]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateRole([Required] string roleName)
        {
            var result = await _userService.CreateRole(roleName);
            if (result.IsSuccess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteMember/{userId}")]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser([Required] string userId)
        {
            var result = await _userService.RemoveUser(userId);
            if (result.IsSuccess == true)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
