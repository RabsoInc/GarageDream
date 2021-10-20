using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.BaseModels.CRM;
using Models.ViewModels.CRM;
using Services.Interfaces.CRM;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class AddressController : Controller
    {
        private readonly ICustomer CustomerService;
        private readonly IAddress AddressService;
        private readonly IContactMethodType ContactMethodTypeService;
        private readonly ICustomerContactDetail CustomerContactDetailService;

        public AddressController(IAddress AddressService,
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
        public IActionResult Manage(Guid CustomerId)
        {
            ContactDetailsViewModel model = new();
            model.Customer = CustomerService.ReturnSingleRecord(CustomerId);
            model.AllCustomerContactDetails = CustomerContactDetailService.ReturnAllRecords(CustomerId);
            model.Address = AddressService.ReturnSingleRecord(model.Customer.Address.AddressId);
            if (model.Address == null)
            {
                model.Address = new();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(ContactDetailsViewModel model)
        {
            //Manage the address
            if (model.Address.AddressId == Guid.Empty)
            {
                model.Address.AddressId = Guid.NewGuid();
                AddressService.CreateRecord(model.Address);
            }
            else
            {
                AddressService.UpdateRecord(model.Address);
            }
            AddressService.SaveChanges();

            //Link the address to the customer
            Customer customer = CustomerService.ReturnSingleRecord(model.Customer.CustomerId);
            customer.Address = AddressService.ReturnSingleRecord(model.Address.AddressId);
            CustomerService.UpdateRecord(customer);
            AddressService.SaveChanges();

            //Redirect back to the customer
            return RedirectToAction("Manage", new { CustomerId = model.Customer.CustomerId });

        }
    }
}