using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMake VehicleMakeService;

        public VehicleMakeController(IVehicleMake VehicleMakeService)
        {
            this.VehicleMakeService = VehicleMakeService;
        }

        [HttpGet]
        public IActionResult Manage(Guid VehicleMakeId)
        {
            VehicleMakeViewModel model = new();
            model.AllVehicleMakes = VehicleMakeService.ReturnAllRecords();
            if (VehicleMakeId == Guid.Empty)
            {
                model.VehicleMake = new();
            }
            else
            {
                model.VehicleMake = VehicleMakeService.ReturnSingleRecord(VehicleMakeId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(VehicleMakeViewModel model)
        {
            if (model.VehicleMake.VehicleMakeId == Guid.Empty)
            {
                model.VehicleMake.VehicleMakeId = Guid.NewGuid();
                VehicleMakeService.CreateRecord(model.VehicleMake);
            }
            else
            {
                VehicleMakeService.UpdateRecord(model.VehicleMake);
            }
            VehicleMakeService.SaveChanges();
            return RedirectToAction("Manage");
        }
    }
}
