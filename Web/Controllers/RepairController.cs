using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Models.BaseModels.Repair;
using Models.ViewModels.CRM;
using Models.ViewModels.Repair;
using Services.Interfaces.Dapper;
using Services.Interfaces.Generic;
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
        private readonly IStaticLists StaticListService;
        private readonly IRepairCategory RepairCategoryService;
        private readonly IRepairInstruction RepairInstructionService;
        private readonly IRepairStatus RepairStatusService;
        private readonly IWorkArea WorkAreaService;

        public RepairController(IRepairHeader RepairHeaderService,
                                IVehicle VehicleService,
                                IDapper DapperService,
                                IConfiguration ConfigurationService,
                                IStaticLists StaticListService,
                                IRepairCategory RepairCategoryService,
                                IRepairInstruction RepairInstructionService,
                                IRepairStatus RepairStatusService,
                                IWorkArea WorkAreaService)
        {
            this.RepairHeaderService = RepairHeaderService;
            this.VehicleService = VehicleService;
            this.DapperService = DapperService;
            this.ConfigurationService = ConfigurationService;
            this.StaticListService = StaticListService;
            this.RepairCategoryService = RepairCategoryService;
            this.RepairInstructionService = RepairInstructionService;
            this.RepairStatusService = RepairStatusService;
            this.WorkAreaService = WorkAreaService;
        }

        [HttpGet]
        public IActionResult RepairSummary(Guid RepairHeaderId, Guid RepairInstructionId, bool LoadEditInstruction)
        {
            DapperService.SetRepairHeaderStatus(ConfigurationService.GetConnectionString("Default"), RepairHeaderId);
            
            RepairViewModel model = new();
            model.RepairCategoryViewModel = new();
            model.RepairInstructionViewModel = new();
            model.ScheduleRepair = new();
            model.RepairHeader = RepairHeaderService.ReturnSingleRecord(RepairHeaderId);
            model.RepairHeaderStatusPerc = RepairStatusService.CalculateRepairStatusPerc(model.RepairHeader.RepairStatus);
            model.RepairCategoryViewModel.RepairCategory = new();
            model.RepairCategoryViewModel.AllRepairCategories = RepairCategoryService.ReturnAllRecords();
            model.RepairInstructionViewModel.AllRepairInstructions = RepairInstructionService.ReturnAllRecords();

            if(RepairInstructionId == Guid.Empty)
            {
                model.RepairInstructionViewModel.RepairInstruction = new();
            }
            else
            {
                model.RepairInstructionViewModel.RepairInstruction = RepairInstructionService.ReturnSingleRecord(RepairInstructionId);
            }

            ViewBag.RepairCategories = new SelectList(RepairCategoryService.GenerateDropDowns(), "RepairCategoryId", "RepairCategoryDescription");
            ViewBag.WorkAreas = new SelectList(WorkAreaService.GenerateDropDowns(), "WorkAreaId", "WorkAreaDescription");
            ViewBag.Numbers = new SelectList(StaticListService.Numbers(1, 25));
            ViewBag.LoadEditInstruction = LoadEditInstruction;


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

            DapperService.SetRepairHeaderStatus(ConfigurationService.GetConnectionString("Default"), primaryKey);

            return RedirectToAction("RepairSummary", new { RepairHeaderId = primaryKey });
        }
    }
}
