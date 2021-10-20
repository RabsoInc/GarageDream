using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.BaseModels.CRM;
using Models.ViewModels.CRM;
using Services.Interfaces.CRM;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class ContactMethodTypeController : Controller
    {
        private readonly IContactMethodType ContactMethodTypeService;

        public ContactMethodTypeController(IContactMethodType ContactMethodTypeService)
        {
            this.ContactMethodTypeService = ContactMethodTypeService;
        }

        [HttpGet]
        public IActionResult Manage(Guid ContactMethodTypeId)
        {
            ContactMethodTypeViewModel model = new();
            model.AllContactMethodType = ContactMethodTypeService.ReturnAllRecords();
            if (ContactMethodTypeId == Guid.Empty)
            {
                model.ContactMethodType = new();
            }
            else
            {
                model.ContactMethodType = ContactMethodTypeService.ReturnSingleRecord(ContactMethodTypeId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(ContactMethodType ContactMethodType)
        {
            if (ContactMethodType.ContactMethodTypeId == Guid.Empty)
            {
                ContactMethodType.ContactMethodTypeId = Guid.NewGuid();
                ContactMethodTypeService.CreateRecord(ContactMethodType);
            }
            else
            {
                ContactMethodTypeService.UpdateRecord(ContactMethodType);
            }
            ContactMethodTypeService.SaveChanges();
            return RedirectToAction("Manage");
        }


    }
}
