using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.BaseModels.CRM;
using Models.ViewModels.CRM;
using Services.Interfaces.CRM;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class TitleController : Controller
    {
        private readonly ITitle TitleService;

        public TitleController(ITitle TitleService)
        {
            this.TitleService = TitleService;
        }

        [HttpGet]
        public IActionResult Manage(Guid TitleId)
        {
            TitleViewModel model = new();
            model.AllTitles = TitleService.ReturnAllRecords();
            if (TitleId == Guid.Empty)
            {
                model.Title = new();
            }
            else
            {
                model.Title = TitleService.ReturnSingleRecord(TitleId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(Title Title)
        {
            if (Title.TitleId == Guid.Empty)
            {
                Title.TitleId = Guid.NewGuid();
                TitleService.CreateRecord(Title);
            }
            else
            {
                TitleService.UpdateRecord(Title);
            }
            TitleService.SaveChanges();
            return RedirectToAction("Manage");
        }
    }
}
