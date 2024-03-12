using Microsoft.AspNetCore.Identity;

namespace API_User.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
