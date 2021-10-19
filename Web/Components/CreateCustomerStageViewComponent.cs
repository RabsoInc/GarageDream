using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ComponentModels;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Web.Components
{
    [ViewComponent]
    public class CreateCustomerStageViewComponent : ViewComponent
    {
        private readonly ICustomer CustomerService;
        private readonly IConfiguration ConfigurationService;
        private readonly IDapper DapperService;

        public CreateCustomerStageViewComponent(ICustomer CustomerService, 
                                                IConfiguration ConfigurationService,
                                                IDapper DapperService)
        {
            this.CustomerService = CustomerService;
            this.ConfigurationService = ConfigurationService;
            this.DapperService = DapperService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid CustomerId)
        {
            CustomerCreationStageComponentModel model = new();
            if (CustomerId == Guid.Empty)
            {
                model.Customer = new();
                model.HasContactDetails = false;
                model.HasAddress = false;
                model.HasVehicals = false;
                model.CountOfNotes = 0;
            }
            else
            {
                model.Customer = CustomerService.ReturnSingleRecord(CustomerId);
                model.HasContactDetails = DapperService.CustomerHasContactDetails(CustomerId, ConfigurationService.GetConnectionString("Default"));
                model.HasAddress = DapperService.CustomerHasAddress(CustomerId, ConfigurationService.GetConnectionString("Default"));
                model.HasVehicals = DapperService.CustomerHasVehicles(CustomerId, ConfigurationService.GetConnectionString("Default"));
                model.CountOfNotes = 0;
            }
            return View(model);
        }
    }
}
