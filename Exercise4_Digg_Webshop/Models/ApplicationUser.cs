using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Exercise4_Digg_Webshop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full Name")]
        public string ?FullName { get; set; }
    }
}
