using Microsoft.AspNetCore.Mvc;
using Minibus_Hire_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserService userService;
        public CustomerController(IUserService _userService)
        {
            userService = _userService;
        }
        public IActionResult Index()
        {
            var model = userService.GetCustomer();
            return View(model);
        }
    }
}
