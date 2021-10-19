using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Models.BaseModels.System;
using Models.ViewModels;
using Services.Interfaces;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class SystemJobController : Controller
    {
        private readonly ISystemJob SystemJobService;
        private readonly IDapper DapperService;
        private readonly IConfiguration ConfigurationService;
        private readonly IStaticLists StaticListsService;
        private readonly ISystemJobHistory SystemJobHistoryService;
        private readonly IDiarySlot DiarySlotService;

        public SystemJobController(ISystemJob SystemJobService,
                                   IDapper DapperService,
                                   IConfiguration ConfigurationService,
                                   IStaticLists StaticListsService,
                                   ISystemJobHistory SystemJobHistoryService,
                                   IDiarySlot DiarySlotService)
        {
            this.SystemJobService = SystemJobService;
            this.DapperService = DapperService;
            this.ConfigurationService = ConfigurationService;
            this.StaticListsService = StaticListsService;
            this.SystemJobHistoryService = SystemJobHistoryService;
            this.DiarySlotService = DiarySlotService;
        }


        [HttpGet]
        public IActionResult Manage(Guid SystemJobId)
        {
        
            SystemJobViewModel model = new();
            model.AllSystemJobs = DapperService.GenerateSystemJobHistory(ConfigurationService.GetConnectionString("Default"));
            
            if (SystemJobId == Guid.Empty)
            {
                model.SystemJob = new();
            }
            else
            {
                model.SystemJob = SystemJobService.ReturnSingleRecord(SystemJobId);
            }

            ViewBag.YesNo = new SelectList(StaticListsService.YesNo(), "DbValue", "FriendlyName");

            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(SystemJobViewModel model)
        {
            if (model.SystemJob.SystemJobId == Guid.Empty)
            {
                model.SystemJob.SystemJobId = Guid.NewGuid();
                SystemJobService.CreateRecord(model.SystemJob);
            }
            else
            {
                SystemJobService.UpdateRecord(model.SystemJob);
            }
            SystemJobService.SaveChanges();
            return RedirectToAction("Manage");
        }

        [HttpGet]
        public IActionResult RunSystemJob(Guid SystemJobId)
        {
            SystemJob Job = SystemJobService.ReturnSingleRecord(SystemJobId);
            
            DapperService.ManualRunSystemJob(
                Job
                , ConfigurationService.GetConnectionString("Default"));

            DiarySlotService.PopulateDiarySlots();
            
            SystemJobHistory history = new();
            history.SystemJobHistoryId = Guid.NewGuid();
            history.SystemJob = Job;
            history.DateExecuted = DateTime.Now;
            history.AutoExecuted = false;

            SystemJobHistoryService.CreateNewRecord(history);
            SystemJobHistoryService.SaveChanges();


            return RedirectToAction("Manage");
        }
    }
}
