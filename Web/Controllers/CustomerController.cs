using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Models.BaseModels.CRM;
using Models.ViewModels.CRM;
using Models.ViewModels.Repair;
using Models.ViewModels.Vehicles;
using Services.Interfaces.CRM;
using Services.Interfaces.Dapper;
using Services.Interfaces.Repair;
using Services.Interfaces.Vehicles;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        private readonly IGender GenderService;
        private readonly IRepairHeader RepairHeaderService;
        private readonly ITitle TitleService;
        private readonly IVehicle VehicleService;
        private readonly ICustomer CustomerService;
        private readonly IDapper DapperService;
        private readonly IAddress AddressService;
        private readonly IConfiguration ConfigurationService;
        public CustomerController(IAddress AddressService,
                                  IConfiguration ConfigurationService,
                                  ICustomer CustomerService,
                                  IDapper DapperService,
                                  IGender GenderService,
                                  IRepairHeader RepairHeaderService,
                                  ITitle TitleService,
                                  IVehicle VehicleService)
        {
            this.GenderService = GenderService;
            this.RepairHeaderService = RepairHeaderService;
            this.TitleService = TitleService;
            this.VehicleService = VehicleService;
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
            model.NewRepair = new();

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

        public JsonResult GetVehiclesByCustomer(Guid CustomerId)
        {
            List<VehicleCustomSelectViewModel> vehicles = VehicleService.ReturnAllRecordsByCustomerId_CustomDisplay(CustomerId);
            return Json(new SelectList(vehicles, "VehicleId","SelectDescription"));
        }

        public JsonResult GetRepairsByCustomer(Guid CustomerId)
        {
            List<RepairCustomSelectViewModel> repairs = RepairHeaderService.ReturnAllRecordsByCustomerId_CustomDisplay(CustomerId);
            return Json(new SelectList(repairs, "RepairId", "SelectDescription"));
        }
    }
}
