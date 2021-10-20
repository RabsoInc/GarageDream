using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.BaseModels.Repair;
using Models.ViewModels.CRM;
using Models.ViewModels.Repair;
using Services.Interfaces.Repair;
using Services.Interfaces.Vehicles;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class RepairController : Controller
    {
        private readonly IRepairHeader RepairHeaderService;
        private readonly IVehicle VehicleService;

        public RepairController(IRepairHeader RepairHeaderService, IVehicle VehicleService)
        {
            this.RepairHeaderService = RepairHeaderService;
            this.VehicleService = VehicleService;
        }

        [HttpGet]
        public IActionResult RepairSummary(Guid RepairHeaderId)
        {
            RepairViewModel model = new();
            model.RepairHeader = RepairHeaderService.ReturnSingleRecord(RepairHeaderId);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateRepair(CustomerIndexViewModel model)
        {
            Guid primaryKey = Guid.NewGuid();

            RepairHeader repairHeader = new();
            repairHeader.RepairHeaderId = primaryKey;
            repairHeader.JobBooked = DateTime.Now;
            repairHeader.Vehicle = VehicleService.ReturnSingleRecord(model.NewRepair.VehicleId);

            RepairHeaderService.CreateRecord(repairHeader);
            RepairHeaderService.SaveChanges();
            
            return RedirectToAction("RepairSummary", new { RepairHeaderId = primaryKey });
        }
    }
}
