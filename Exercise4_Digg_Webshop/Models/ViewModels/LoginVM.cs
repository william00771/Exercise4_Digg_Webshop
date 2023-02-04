using System.ComponentModel.DataAnnotations;

namespace Exercise4_Digg_Webshop.Models.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Email Adress is Required")]
        public string EmailAdress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)] //I guess it hides the password?
        public string Password { get; set; }
    }
}
