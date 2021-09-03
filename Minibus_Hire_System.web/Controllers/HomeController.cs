using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.web.Models;
using Minibus_Hire_System.web.Models.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;
        private readonly IVehicleService vehicleService;
        private readonly IBookingService bookingService;

        public HomeController(ILogger<HomeController> logger, IUserService _userService, IVehicleService _vehicleService, IBookingService _bookingService)
        {
            _logger = logger;
            userService = _userService;
            vehicleService = _vehicleService;
            bookingService = _bookingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel _model)
        {
            if (!ModelState.IsValid)
                return View(_model);

            return View();
        }

        public IActionResult Vehicle()
        {
            var model = vehicleService.GetListOfVehicle();
            return View(model.AsEnumerable());
        }

        public IActionResult MakeBooking(Guid vehicleID)
        {
            HttpContext.Session.SetString("BookingVehicle", vehicleID.ToString());
            if (User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(Booking));
            else
                return RedirectToAction(nameof(Index), nameof(SignIn));
        }

        [HttpGet]
        public bool checkRedirect()
        {
            return !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("BookingVehicle") ?? string.Empty);
        }

        [Authorize]
        public IActionResult Booking()
        {
            var _vehicleID = HttpContext.Session.GetString("BookingVehicle") ?? string.Empty;
            if (string.IsNullOrWhiteSpace(_vehicleID))
                return RedirectToAction(nameof(Index));
            var model = new BookingViewModel();
            model.Vehicle = vehicleService.GetVehicleByID(Guid.Parse(_vehicleID));
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Booking(BookingViewModel model)
        {
            var _vehicleId = HttpContext.Session.GetString("BookingVehicle") ?? string.Empty;

            if (string.IsNullOrWhiteSpace(_vehicleId))
                return RedirectToAction(nameof(Index));
            else
            {
                var vehicleId = Guid.Parse(_vehicleId);
                model.Vehicle = vehicleService.GetVehicleByID(vehicleId);
                if (!ModelState.IsValid)
                    return View(model);

                
                var userId = Guid.Parse(User.Claims.Where(m => m.Type == ClaimTypes.NameIdentifier).Select(m => m.Value).FirstOrDefault());
                var result = bookingService.AddBooking(new Object.BookingObject
                {
                    Booking_Date = model.Booking_Date,
                    Booking_Description = model.Booking_Description,
                    Booking_Type = model.Booking_Type,
                    CardNumber = model.CardNumber,
                    CardSecurityNumber = model.CardSecurityNumber,
                    PaymentType = model.PaymentType,
                    SortCode = model.SortCode,
                    UserLicenseNumber = model.UserLicenseNumber,
                    Vehicle_ID = vehicleId,
                    User_ID = userId
                });
                if (result)
                    return RedirectToAction(nameof(Index));
                else
                    return View(model);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
