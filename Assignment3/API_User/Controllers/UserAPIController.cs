using API_User.Models.Dtos;
using API_User.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> GetMembers()
        {
            var result = await _userService.GetUsers();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetMemberByUserID/{userId}")]
        public async Task<IActionResult> GetMemberByUserID([Required] string userId)
        {
            var result = await _userService.GetMemberByUserId(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] MemberAddEditDto model)
        {
            var result = await _userService.CreateUser(model);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddEditMember([FromBody] MemberAddEditDto model)
        {
            var result = await _userService.UpdateUser(model);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteMember")]
        public async Task<IActionResult> DeleteMember([Required] string userId)
        {
            var result = await _userService.RemoveUser(userId);
            if (result == true)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
