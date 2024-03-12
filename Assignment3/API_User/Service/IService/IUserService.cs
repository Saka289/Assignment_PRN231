using API_User.Models;
using API_User.Models.Dtos;

namespace API_User.Service.IService
{
    public interface IUserService
    {
        Task<ResponseDto> GetUsers();
        Task<ResponseDto> GetUserByUserId(string userId);
        Task<ResponseDto> GetUserByEmail(string email);
        Task<ResponseDto> CreateUser(UserAddEditDto model);
        Task<ResponseDto> UpdateUser(UserAddEditDto model);
        Task<ResponseDto> RemoveUser(string userId);
        Task<ResponseDto> CreateRole(string roleName);
    }
}
