using Microsoft.AspNetCore.Identity;

namespace Session18.Users.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
