using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.Vehicles;
using Services.Interfaces;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModel VehicleModelService;
        private readonly IVehicleMake VehicleMakeService;

        public VehicleModelController(IVehicleModel VehicleModelService, IVehicleMake VehicleMakeService)
        {
            this.VehicleModelService = VehicleModelService;
            this.VehicleMakeService = VehicleMakeService;
        }

        [HttpGet]
        public IActionResult Manage(Guid VehicleModelId)
        {
            VehicleModelViewModel model = new();
            model.AllVehicleModels = VehicleModelService.ReturnAllRecords();
            if (VehicleModelId == Guid.Empty)
            {
                model.VehicleModel = new();
            }
            else
            {
                model.VehicleModel = VehicleModelService.ReturnSingleRecord(VehicleModelId);
            }

            ViewBag.VehicalMakes = new SelectList(VehicleMakeService.GenerateDropDowns(), "VehicleMakeId", "VehicleMakeDescription");

            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(VehicleModelViewModel model)
        {
            model.VehicleModel.VehicleMake = VehicleMakeService.ReturnSingleRecord(model.VehicleModel.VehicleMake.VehicleMakeId);

            if (model.VehicleModel.VehicleModelId == Guid.Empty)
            {
                model.VehicleModel.VehicleModelId = Guid.NewGuid();
                VehicleModelService.CreateRecord(model.VehicleModel);
            }
            else
            {
                VehicleModelService.UpdateRecord(model.VehicleModel);
            }
            VehicleModelService.SaveChanges();

            return RedirectToAction("Manage");
        }
    }
}
