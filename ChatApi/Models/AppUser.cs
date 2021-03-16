using Microsoft.AspNetCore.Identity;

namespace ChatApi.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string ProfileUrl { get; set; }
    }
}