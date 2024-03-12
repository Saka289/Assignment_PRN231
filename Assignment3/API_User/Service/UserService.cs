using API_User.Data;
using API_User.Models;
using API_User.Models.Dtos;
using API_User.Service.IService;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API_User.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        public async Task<ResponseDto> CreateUser(UserAddEditDto model)
        {
            try
            {
                ApplicationUser user = new()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToLower(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    EmailConfirmed = true
                };
                var addUser = await _userManager.CreateAsync(user, model.Password);
                if (addUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "USER");
                }
                else
                {
                    _response.Result = true;
                    _response.IsSuccess = false;
                    _response.Message = addUser.Errors.FirstOrDefault().Description.ToString();
                    return _response;
                }
                _response.IsSuccess = true;
                _response.Result = true;
                _response.Message = "Create Successfully !!!";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public async Task<ResponseDto> UpdateUser(UserAddEditDto model)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    _response.Result = false;
                    _response.IsSuccess = false;
                    _response.Message = "Not found !!!";
                    return _response;
                }
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.UserName = model.Email;

                if (!string.IsNullOrEmpty(model.Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    var result = await _userManager.AddPasswordAsync(user, model.Password);
                    if (!result.Succeeded)
                    {
                        _response.Result = true;
                        _response.IsSuccess = false;
                        _response.Message = result.Errors.FirstOrDefault().Description.ToString();
                        return _response;
                    }
                }
                _response.IsSuccess = true;
                _response.Result = true;
                _response.Message = "Update Successfully !!!";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        public async Task<ResponseDto> GetUserByEmail(string email)
        {
            try
            {
                var users = await _userManager.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
                if (users == null)
                {
                    _response.Result = false;
                    _response.Message = "Not found.";
                    _response.IsSuccess = false;
                    return _response;
                }
                _response.Result = _mapper.Map<UserDto>(users);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public async Task<ResponseDto> GetUserByUserId(string userId)
        {
            try
            {
                var users = await _userManager.Users.Where(u => u.Id.Equals(userId)).FirstOrDefaultAsync();
                if (users == null)
                {
                    _response.Result = false;
                    _response.Message = "Not found.";
                    _response.IsSuccess = false;
                    return _response;
                }
                _response.Result = _mapper.Map<UserDto>(users);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public async Task<ResponseDto> GetUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                if (users == null)
                {
                    _response.Result = false;
                    _response.Message = "Not found.";
                    _response.IsSuccess = false;
                    return _response;
                }
                _response.Result = _mapper.Map<IEnumerable<UserDto>>(users);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public async Task<ResponseDto> RemoveUser(string userId)
        {
            try
            {
                var user = await _userManager.Users.Where(u => u.Id.Equals(userId)).FirstOrDefaultAsync();
                if (user == null)
                {
                    _response.Result = false;
                    _response.IsSuccess = false;
                    _response.Message = "Not found !!!";
                    return _response;
                }
                await _userManager.DeleteAsync(user);
                _response.Result = true;
                _response.Message = "Remove Successfully !!!";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public async Task<ResponseDto> CreateRole(string roleName)
        {
            try
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
                else
                {
                    _response.Result = false;
                    _response.IsSuccess = false;
                    _response.Message = "Create Role Failed !!!";
                    return _response;
                }
                _response.Result = true;
                _response.Message = "Create Role Successfully !!!";
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
