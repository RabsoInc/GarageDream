using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Models.BaseModels.CRM;
using Models.ViewModels.CRM;
using Services.Interfaces;
using Services.Interfaces.CRM;
using Services.Interfaces.Dapper;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        private readonly IGender GenderService;
        private readonly ITitle TitleService;
        private readonly ICustomer CustomerService;
        private readonly IDapper DapperService;
        private readonly IAddress AddressService;
        private readonly IConfiguration ConfigurationService;
        public CustomerController(IAddress AddressService,
                                  IConfiguration ConfigurationService,
                                  ICustomer CustomerService,
                                  IDapper DapperService,
                                  IGender GenderService,
                                  ITitle TitleService)
        {
            this.GenderService = GenderService;
            this.TitleService = TitleService;
            this.CustomerService = CustomerService;
            this.DapperService = DapperService;
            this.AddressService = AddressService;
            this.ConfigurationService = ConfigurationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CustomerIndexViewModel model = new();
            model.Customers = DapperService.GenerateCustomerIndexView(ConfigurationService.GetConnectionString("Default"));
            return View(model);
        }

        [HttpGet]
        public IActionResult Manage(Guid CustomerId)
        {
            Customer model;

            if (CustomerId == Guid.Empty)
            {
                model = new();
            }
            else
            {
                model = CustomerService.ReturnSingleRecord(CustomerId);
            }

            ViewBag.Titles = new SelectList(TitleService.GenerateDropDowns(),"TitleId", "TitleDescription");
            ViewBag.Genders = new SelectList(GenderService.GenerateDropDowns(), "GenderId", "GenderDescription");
            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(Customer Customer)
        {
            Customer.Title = TitleService.ReturnSingleRecord(Customer.Title.TitleId);
            Customer.Gender = GenderService.ReturnSingleRecord(Customer.Gender.GenderId);
            if (Customer.CustomerId == Guid.Empty)
            {
                Customer.CustomerId = Guid.NewGuid();
                CustomerService.CreateRecord(Customer);
            }
            else
            {
                CustomerService.UpdateRecord(Customer);
            }
            CustomerService.SaveChanges();
            return RedirectToAction("Manage", "Customer", new { CustomerId = Customer.CustomerId });
        }
    }
}
