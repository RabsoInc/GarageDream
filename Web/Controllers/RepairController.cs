using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.BaseModels.Repair;
using Models.ViewModels.CRM;
using Models.ViewModels.Repair;
using Services.Interfaces.Dapper;
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
        private readonly IDapper DapperService;
        private readonly IConfiguration ConfigurationService;
        private readonly IRepairStatus RepairStatusService;

        public RepairController(IRepairHeader RepairHeaderService,
                                IVehicle VehicleService,
                                IDapper DapperService,
                                IConfiguration ConfigurationService,
                                IRepairStatus RepairStatusService)
        {
            this.RepairHeaderService = RepairHeaderService;
            this.VehicleService = VehicleService;
            this.DapperService = DapperService;
            this.ConfigurationService = ConfigurationService;
            this.RepairStatusService = RepairStatusService;
        }

        [HttpGet]
        public IActionResult RepairSummary(Guid RepairHeaderId)
        {
            DapperService.SetRepairHeaderStatus(ConfigurationService.GetConnectionString("Default"), RepairHeaderId);
            
            RepairViewModel model = new();
            model.RepairHeader = RepairHeaderService.ReturnSingleRecord(RepairHeaderId);
            model.RepairHeaderStatusPerc = RepairStatusService.CalculateRepairStatusPerc(model.RepairHeader.RepairStatus);

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
