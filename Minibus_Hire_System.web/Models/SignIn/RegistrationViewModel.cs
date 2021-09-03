using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Models.SignIn
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address1 is Required")]
        [Display(Name = "Address1")]
        public string Address1 { get; set; }

        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Display(Name = "Address3")]
        public string Address3 { get; set; }

        [Required(ErrorMessage = "Post code is Required")]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "County is Required")]
        [Display(Name = "County")]
        public string County { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [StringLength(7, ErrorMessage = "Invalid Country Name", MinimumLength = 2)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required")]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(25, ErrorMessage = "Password must me between 8 to 25 characters", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(dataType: DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password does not match with password")]
        public string ConfirmPassword { get; set; }
    }
}
