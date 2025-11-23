using Microsoft.AspNetCore.Identity;

namespace WebOdevi.Models
{
    public class User :IdentityUser
    {
        public string fullName { get; set; }
    }
}
