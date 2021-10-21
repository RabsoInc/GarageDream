using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels.Repair;
using Services.Interfaces.Repair;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class RepairCategoryController : Controller
    {
        private readonly IRepairCategory RepairCategoryService;

        public RepairCategoryController(IRepairCategory RepairCategoryService)
        {
            this.RepairCategoryService = RepairCategoryService;
        }

        [HttpPost]
        public IActionResult Manage(RepairViewModel model)
        {
          
            if(model.RepairCategoryViewModel.RepairCategory.RepairCategoryId == Guid.Empty)
            {
                model.RepairCategoryViewModel.RepairCategory.RepairCategoryId = Guid.NewGuid();
                RepairCategoryService.CreateRecord(model.RepairCategoryViewModel.RepairCategory);
            }
            else
            {
                RepairCategoryService.UpdateRecord(model.RepairCategoryViewModel.RepairCategory);
            }
            RepairCategoryService.SaveChanges();

            return RedirectToAction("RepairSummary", "Repair", new { RepairHeaderId = model.RepairHeader.RepairHeaderId});
        }
    }
}
