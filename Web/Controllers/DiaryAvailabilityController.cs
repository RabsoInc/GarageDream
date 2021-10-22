using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Models.InternalViewModels;
using Models.ViewModels.Diary;
using Models.ViewModels.Repair;
using Services.Interfaces.Dapper;
using Services.Interfaces.Diary;
using Services.Interfaces.Repair;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class DiaryAvailabilityController : Controller
    {
        private readonly IWorkArea WorkAreaService;
        private readonly IDapper DapperService;
        private readonly IConfiguration ConfigurationService;
        private readonly IDiarySlot DiarySlotService;

        public DiaryAvailabilityController(IWorkArea WorkAreaService, IDapper DapperService, IConfiguration ConfigurationService, IDiarySlot DiarySlotService)
        {
            this.WorkAreaService = WorkAreaService;
            this.DapperService = DapperService;
            this.ConfigurationService = ConfigurationService;
            this.DiarySlotService = DiarySlotService;
        }

        [HttpGet]
        public IActionResult Manage(DiarySlotIndexViewModel model)
        {
            if(model.DiarySlotFilters == null)
            {
                model.DiarySlotFilters = new();
            }

            model.DiarySlots = DapperService.GenerateDiarySlotsIndexView(ConfigurationService.GetConnectionString("Default"), model.DiarySlotFilters);
            model.DiarySlotAdjustment = new();
            ViewBag.WorkAreas = new SelectList(WorkAreaService.GenerateDropDowns(), "WorkAreaId", "WorkAreaDescription");

            return View(model);
        }

        [HttpPost]
        public IActionResult AdjustSlots(DiarySlotIndexViewModel model)
        {
            DiarySlotService.RemoveExcessSlots(model.DiarySlotAdjustment);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public IActionResult ScheduleJob(RepairViewModel model)
        {
            // Book the slots
            DapperService.ConfirmAndBookDiarySlots(ConfigurationService.GetConnectionString("Default"), 
                model.ScheduleRepair.UnitsRequired, 
                model.ScheduleRepair.SelectedDate.ToShortDateString(), 
                model.ScheduleRepair.WorkAreaDescription, 
                model.ScheduleRepair.RepairInstructionId);
            return RedirectToAction("RepairSummary", "Repair", new { RepairHeaderId = model.RepairHeader.RepairHeaderId });
        }

        [HttpGet]
        public JsonResult GetAvailableSlots(int SlotsRequired, string WorkAreaDescription)
        {
            List<DiarySlotsAvailableInternalModel> model = DapperService.GetAvailableDiarySlots(ConfigurationService.GetConnectionString("Default"), SlotsRequired, WorkAreaDescription);
            return Json(new SelectList(model, "AvailableDate", "AvailableDate"));
        }
    }
}
