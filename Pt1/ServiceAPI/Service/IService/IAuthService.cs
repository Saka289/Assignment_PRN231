using RepositoryAPI.Models.Dto;

namespace ServiceAPI.Service.IService;

public interface IAuthService
{
    Task<string> Register(RegistrationRequestDto registrationRequestDto);

    Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

    Task<bool> AssignRole(string email, string roleName);
}