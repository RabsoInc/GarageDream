using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.BaseModels.Vehicles;
using Models.ViewModels.Vehicles;
using Services.Interfaces;
using Services.Interfaces.CRM;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class VehicleController : Controller
    {
        private readonly IVehicle VehicleService;
        private readonly ICustomer CustomerService;
        private readonly IVehicleMake VehicleMakeService;
        private readonly IVehicleModel VehicleModelService;
        private readonly IFuelType FuelTypeService;

        public VehicleController(IVehicle VehicleService,
                                 ICustomer CustomerService,
                                 IFuelType FuelTypeService,
                                 IVehicleMake VehicleMakeService,
                                 IVehicleModel VehicleModelService)
        {
            this.VehicleService = VehicleService;
            this.CustomerService = CustomerService;
            this.VehicleMakeService = VehicleMakeService;
            this.VehicleModelService = VehicleModelService;
            this.FuelTypeService = FuelTypeService;
        }

        public JsonResult GetVehicleModels(Guid VehicleMakeId)
        {
            List<VehicleModel> vehicleModels = VehicleModelService.ReturnAllRecordsByVehicleMake(VehicleMakeId);
            vehicleModels.Insert(0, new VehicleModel { VehicleModelId = Guid.Empty, VehicleModelDescription = "Please select vehicle model" });
            return Json(new SelectList(vehicleModels, "VehicleModelId", "VehicleModelDescription"));
        }

        public IActionResult Manage(Guid VehicleId, Guid CustomerId)
        {
            VehicleViewModel model = new VehicleViewModel();
            model.Customer = CustomerService.ReturnSingleRecord(CustomerId);
            model.AllVehicles = VehicleService.ReturnAllRecordsByCustomerId(CustomerId);
            if(VehicleId == Guid.Empty)
            {
                model.Vehicle = new();
            }
            else
            {
                model.Vehicle = VehicleService.ReturnSingleRecord(VehicleId);
            }

            ViewBag.VehicalMakes = new SelectList(VehicleMakeService.GenerateDropDowns(), "VehicleMakeId", "VehicleMakeDescription");
            ViewBag.VehicalModels = new SelectList(VehicleModelService.GenerateDropDowns(), "VehicleModelId", "VehicleModelDescription");
            ViewBag.FuelTypes = new SelectList(FuelTypeService.GenerateDropDowns(), "FuelTypeId", "FuelTypeDescription");

            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(VehicleViewModel model)
        {
            model.Vehicle.VehicleMake = VehicleMakeService.ReturnSingleRecord(model.Vehicle.VehicleMake.VehicleMakeId);
            model.Vehicle.VehicleModel = VehicleModelService.ReturnSingleRecord(model.Vehicle.VehicleModel.VehicleModelId);
            model.Vehicle.Customer = CustomerService.ReturnSingleRecord(model.Customer.CustomerId);
            model.Vehicle.FuelType = FuelTypeService.ReturnSingleRecord(model.Vehicle.FuelType.FuelTypeId);

            if(model.Vehicle.VehicleId == Guid.Empty)
            {
                model.Vehicle.VehicleId = Guid.NewGuid();
                VehicleService.CreateRecord(model.Vehicle);
                VehicleService.SaveChanges();
            }
            else
            {
                VehicleService.UpdateRecord(model.Vehicle);
                VehicleService.SaveChanges();
            }

            return RedirectToAction("Manage", new { CustomerId = model.Vehicle.Customer.CustomerId});
        }
    }
}
