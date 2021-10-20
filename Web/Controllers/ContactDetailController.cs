using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.CRM;
using Services.Interfaces.CRM;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class ContactDetailController : Controller
    {
        private readonly ICustomer CustomerService;
        private readonly IAddress AddressService;
        private readonly IContactMethodType ContactMethodTypeService;
        private readonly ICustomerContactDetail CustomerContactDetailService;

        public ContactDetailController(IAddress AddressService,
                                       IContactMethodType ContactMethodTypeService,
                                       ICustomer CustomerService,
                                       ICustomerContactDetail CustomerContactDetailService)
        {
            this.CustomerService = CustomerService;
            this.AddressService = AddressService;
            this.ContactMethodTypeService = ContactMethodTypeService;
            this.CustomerContactDetailService = CustomerContactDetailService;
        }

        [HttpGet]
        public IActionResult Manage(Guid CustomerId, Guid CustomerContactDetailId)
        {
            ContactDetailsViewModel model = new();
            model.Customer = CustomerService.ReturnSingleRecord(CustomerId);
            model.Address = model.Customer.Address;
            model.AllCustomerContactDetails = CustomerContactDetailService.ReturnAllRecords(CustomerId);
            if(CustomerContactDetailId == Guid.Empty)
            {
                model.CustomerContactDetail = new();
            }
            else
            {
                model.CustomerContactDetail = CustomerContactDetailService.ReturnSingleRecord(CustomerContactDetailId);
            }

            ViewBag.ContactMethods = new SelectList(ContactMethodTypeService.GenerateDropDowns(), "ContactMethodTypeId", "ContactMethodTypeDescription");

            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(ContactDetailsViewModel model)
        {
            model.CustomerContactDetail.Customer = CustomerService.ReturnSingleRecord(model.Customer.CustomerId);
            model.CustomerContactDetail.ContactMethodType = ContactMethodTypeService.ReturnSingleRecord(model.CustomerContactDetail.ContactMethodType.ContactMethodTypeId);
            if(model.CustomerContactDetail.CustomerContactDetailId == Guid.Empty)
            {
                model.CustomerContactDetail.CustomerContactDetailId = Guid.NewGuid();
                CustomerContactDetailService.CreateRecord(model.CustomerContactDetail);
            }
            else
            {
                CustomerContactDetailService.UpdateRecord(model.CustomerContactDetail);
            }
            CustomerContactDetailService.SaveChanges();
            return RedirectToAction("Manage", new { CustomerId = model.Customer.CustomerId });
        }
    }
}
