using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Models.SignIn
{
    public class SignInViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string signin_Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string signin_Password { get; set; }
    }
}
