using Microsoft.AspNetCore.Identity;

namespace SuperOnline.Models
{
    public class AppUser : IdentityUser
    {
        public string Nome { get; set; }
    }
}
