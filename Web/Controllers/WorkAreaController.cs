using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class WorkAreaController : Controller
    {
        private readonly IWorkArea WorkAreaService;

        public WorkAreaController(IWorkArea WorkAreaService)
        {
            this.WorkAreaService = WorkAreaService;
        }

        [HttpGet]
        public IActionResult Manage(Guid WorkAreaId)
        {
            WorkAreaViewModel model = new();
            model.AllWorkAreas = WorkAreaService.ReturnAllRecords();
            if (WorkAreaId == Guid.Empty)
            {
                model.WorkArea = new();
            }
            else
            {
                model.WorkArea = WorkAreaService.ReturnSingleRecord(WorkAreaId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(WorkAreaViewModel model)
        {
            if (model.WorkArea.WorkAreaId == Guid.Empty)
            {
                model.WorkArea.WorkAreaId = Guid.NewGuid();
                WorkAreaService.CreateRecord(model.WorkArea);
            }
            else
            {
                WorkAreaService.UpdateRecord(model.WorkArea);
            }
            WorkAreaService.SaveChanges();
            return RedirectToAction("Manage");
        }
    }
}
