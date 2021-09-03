using Microsoft.AspNetCore.Mvc;
using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEncryptPasswordService encryptService;
        public AdminController(IEncryptPasswordService _encryptionService)
        {
            encryptService = _encryptionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PasswordGenerator()
        {
            return View(new PasswordGeneratorViewModel());
        }

        [HttpPost]
        public IActionResult PasswordGenerator(PasswordGeneratorViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                var _hashPassword =
                    encryptService.EncryptPassword(model.Password);
                model.Salt = _hashPassword.Salt;
                model.HashPassword = _hashPassword.HashPassword;
            }
            return View(model);
        }
    }
}
