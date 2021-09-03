using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Minibus_Hire_System.Constant;
using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.web.Models.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Controllers
{
    public class SignInController : Controller
    {
        private readonly IUserService userService;
        private readonly ISecurityService securityService;

        public SignInController(IUserService _userService, ISecurityService _securityService)
        {
            userService = _userService;
            securityService = _securityService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Registration()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<bool> Signin(SignInViewModel model)// string email, string password)
        {
            if (string.IsNullOrWhiteSpace(model.signin_Email) || string.IsNullOrWhiteSpace(model.signin_Password))
                return false;

            ///TODO::need to check the credential in database
            var result = securityService.Authenticate(model.signin_Email, model.signin_Password);
            if (result == null)
                return false;
            else
            {
                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{result.FirstName} {result.LastName}"),
                    new Claim(ClaimTypes.Email, result.UserName),
                    new Claim(ClaimTypes.NameIdentifier, result.UserID.ToString()),
                    new Claim(ClaimTypes.Role, result.Role)
                };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);
                return true;
            }
        }

        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index), nameof(SignIn));
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index), nameof(HomeController));

            var result = userService.AddUser(new Object.NewUserObject
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Address3 = model.Address3,
                PostCode = model.PostCode,
                City = model.City,
                County = model.County,
                Country = model.Country,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Username = model.Email,
                Password = model.Password,
                Role = UserRole.Customer
            });

            if (result)
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction(nameof(Index));
        }

        public IList<string> ValidateRegistration(RegistrationViewModel model)
        {
            IList<string> validation = new List<string>();
            if (string.IsNullOrWhiteSpace(model.FirstName))
                validation.Add("First Name is required");
            if (string.IsNullOrWhiteSpace(model.LastName))
                validation.Add("Last Name is required");

            return validation;
        }
    }
}
