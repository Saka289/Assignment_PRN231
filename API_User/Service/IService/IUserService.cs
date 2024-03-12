using API_User.Models;
using API_User.Models.Dtos;

namespace API_User.Service.IService
{
    public interface IUserService
    {
        Task<IEnumerable<MemberDto>> GetUsers();
        Task<MemberDto> GetMemberByUserId(string userId);
        Task<bool> CreateUser(MemberAddEditDto model);
        Task<bool> UpdateUser(MemberAddEditDto model);
        Task<bool> RemoveUser(string userId);
    }
}
