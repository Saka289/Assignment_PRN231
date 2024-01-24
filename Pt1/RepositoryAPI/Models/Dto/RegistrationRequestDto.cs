namespace RepositoryAPI.Models.Dto;

public class RegistrationRequestDto
{
    public string Email { get; set; }
    
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    
    public string? Role { get; set; }
}