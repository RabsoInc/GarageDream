using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Models.ViewModels.Diary;
using Services.Interfaces.Dapper;
using Services.Interfaces.Diary;
using Services.Interfaces.Repair;

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
    }
}
