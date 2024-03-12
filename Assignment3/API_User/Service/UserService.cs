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
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<bool> CreateUser(MemberAddEditDto model)
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
                string roleName = "Customer";
                _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<MemberDto> GetMemberByUserId(string userId)
        {
            var member = await _userManager.Users.Where(u => u.Id.Equals(userId)).FirstOrDefaultAsync();
            var result = _mapper.Map<MemberDto>(member);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<MemberDto>> GetUsers()
        {
            var members = await _userManager.Users.ToListAsync();
            var result = _mapper.Map<IEnumerable<MemberDto>>(members);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> RemoveUser(string userId)
        {
            var member = await _userManager.Users.Where(u => u.Id.Equals(userId)).FirstOrDefaultAsync();
            if (member == null)
            {
                return false;
            }
            await _userManager.DeleteAsync(member);
            return true;
        }

        public async Task<bool> UpdateUser(MemberAddEditDto model)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return false;
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UserName = model.Email;

            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }
    }
}
