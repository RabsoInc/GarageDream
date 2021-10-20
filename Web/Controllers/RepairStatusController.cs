using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels.Repair;
using Services.Interfaces.Repair;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class RepairStatusController : Controller
    {
        private readonly IRepairStatus RepairStatusService;

        public RepairStatusController(IRepairStatus RepairStatusService)
        {
            this.RepairStatusService = RepairStatusService;
        }

        [HttpGet]
        public IActionResult Manage(Guid RepairStatusId)
        {
            RepairStatusViewModel model = new();
            model.AllRepairStatuses = RepairStatusService.ReturnAllRecords();
            if (RepairStatusId == Guid.Empty)
            {
                model.RepairStatus = new();
            }
            else
            {
                model.RepairStatus = RepairStatusService.ReturnSingleRecord(RepairStatusId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(RepairStatusViewModel model)
        {
            if (model.RepairStatus.RepairStatusId == Guid.Empty)
            {
                model.RepairStatus.RepairStatusId = Guid.NewGuid();
                RepairStatusService.CreateRecord(model.RepairStatus);
            }
            else
            {
                RepairStatusService.UpdateRecord(model.RepairStatus);
            }
            RepairStatusService.SaveChanges();
            return RedirectToAction("Manage");
        }
    }
}
