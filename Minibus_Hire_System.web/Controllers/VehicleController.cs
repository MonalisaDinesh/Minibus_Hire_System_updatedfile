using Microsoft.AspNetCore.Mvc;
using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService _vehicleService)
        {
            vehicleService = _vehicleService;
        }

        public IActionResult Index()
        {
            var model = vehicleService.GetListOfVehicle();
            return View(model);
        }

        public IActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = vehicleService.AddVehicle(new Object.VehicleObject
            {
                Make = model.Make,
                Model = model.Vehicle_Model,
                Mileage = model.Mileage,
                Name_plate = model.Name_plate,
                Vehicle_Type = model.Vehicle_Type,
                Description = model.Description,
                ImageFileName = model.ImageFileName
            });
            if (result)
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        public IActionResult UpdateVehicle(Guid VehicleID)
        {
            var _vehicle = vehicleService.GetVehicleByID(VehicleID);
            var model = new VehicleViewModel
            {
                Vehicle_ID = _vehicle.Vehicle_ID,
                Make = _vehicle.Make,
                Vehicle_Model = _vehicle.Model,
                Mileage = _vehicle.Mileage,
                Name_plate = _vehicle.Name_plate,
                Vehicle_Type = _vehicle.Vehicle_Type,
                ImageFileName = _vehicle.ImageFileName,
                Description = _vehicle.Description
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateVehicle(VehicleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = vehicleService.UpdateVehicle(new Object.VehicleObject
            {
                Make = model.Make,
                Model = model.Vehicle_Model,
                Mileage = model.Mileage,
                Name_plate = model.Name_plate,
                Vehicle_Type = model.Vehicle_Type,
                Description = model.Description,
                ImageFileName = model.ImageFileName
            });
            if (result)
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
    }
}
