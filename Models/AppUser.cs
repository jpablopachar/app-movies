using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace app_movies.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string? FullName { get; set; }
    }
}