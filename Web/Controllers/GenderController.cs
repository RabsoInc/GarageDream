using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.BaseModels.CRM;
using Models.ViewModels.CRM;
using Services.Interfaces.CRM;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class GenderController : Controller
    {
        private readonly IGender GenderService;

        public GenderController(IGender GenderService)
        {
            this.GenderService = GenderService;
        }

        [HttpGet]
        public IActionResult Manage(Guid GenderId)
        {
            GenderViewModel model = new();
            model.AllGenders = GenderService.ReturnAllRecords();
            if (GenderId == Guid.Empty)
            {
                model.Gender = new();
            }
            else
            {
                model.Gender = GenderService.ReturnSingleRecord(GenderId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(Gender Gender)
        {
            if (Gender.GenderId == Guid.Empty)
            {
                Gender.GenderId = Guid.NewGuid();
                GenderService.CreateRecord(Gender);
            }
            else
            {
                GenderService.UpdateRecord(Gender);
            }
            GenderService.SaveChanges();
            return RedirectToAction("Manage");
        }
    }
}
