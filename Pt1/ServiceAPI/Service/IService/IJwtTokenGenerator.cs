using RepositoryAPI.Models;

namespace ServiceAPI.Service.IService;

public interface IJwtTokenGenerator
{
    public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
}