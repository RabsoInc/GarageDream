using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class FuelTypeController : Controller
    {
        private readonly IFuelType FuelTypeService;

        public FuelTypeController(IFuelType FuelTypeService)
        {
            this.FuelTypeService = FuelTypeService;
        }

        [HttpGet]
        public IActionResult Manage(Guid FuelTypeId)
        {
            FuelTypeViewModel model = new();
            model.AllFuelTypes = FuelTypeService.ReturnAllRecords();
            if (FuelTypeId == Guid.Empty)
            {
                model.FuelType = new();
            }
            else
            {
                model.FuelType = FuelTypeService.ReturnSingleRecord(FuelTypeId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(FuelTypeViewModel model)
        {
            if (model.FuelType.FuelTypeId == Guid.Empty)
            {
                model.FuelType.FuelTypeId = Guid.NewGuid();
                FuelTypeService.CreateRecord(model.FuelType);
            }
            else
            {
                FuelTypeService.UpdateRecord(model.FuelType);
            }
            FuelTypeService.SaveChanges();
            return RedirectToAction("Manage");
        }
    }
}
