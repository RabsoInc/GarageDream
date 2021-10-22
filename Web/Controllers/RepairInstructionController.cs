using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ViewModels.Repair;
using Services.Interfaces.Dapper;
using Services.Interfaces.Repair;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class RepairInstructionController : Controller
    {
        private readonly IConfiguration ConfigurationService;
        private readonly IDapper DapperService;
        private readonly IRepairCategory RepairCategoryService;
        private readonly IRepairHeader RepairHeaderService;
        private readonly IRepairInstruction RepairInstructionService;
        private readonly IRepairStatus RepairStatusService;
        private readonly IWorkArea WorkAreaService;

        public RepairInstructionController(
            IConfiguration ConfigurationService,
            IDapper DapperService,
            IRepairCategory RepairCategoryService,
            IRepairHeader RepairHeaderService,
            IRepairInstruction RepairInstructionService,
            IRepairStatus RepairStatusService,
            IWorkArea WorkAreaService)
        {
            this.ConfigurationService = ConfigurationService;
            this.DapperService = DapperService;
            this.RepairCategoryService = RepairCategoryService;
            this.RepairHeaderService = RepairHeaderService;
            this.RepairInstructionService = RepairInstructionService;
            this.RepairStatusService = RepairStatusService;
            this.WorkAreaService = WorkAreaService;
        }

        public IActionResult Manage(RepairViewModel model)
        {
            model.RepairInstructionViewModel.RepairInstruction.RepairCategory = RepairCategoryService.ReturnSingleRecord(model.RepairInstructionViewModel.RepairInstruction.RepairCategory.RepairCategoryId);
            model.RepairInstructionViewModel.RepairInstruction.WorkArea = WorkAreaService.ReturnSingleRecord(model.RepairInstructionViewModel.RepairInstruction.WorkArea.WorkAreaId);
            model.RepairInstructionViewModel.RepairInstruction.RepairHeader = RepairHeaderService.ReturnSingleRecord(model.RepairHeader.RepairHeaderId);
            model.RepairInstructionViewModel.RepairInstruction.RepairStatus = RepairStatusService.ReturnFirstStatus();

            if (model.RepairInstructionViewModel.RepairInstruction.RepairInstructionId == Guid.Empty)
            {
                model.RepairInstructionViewModel.RepairInstruction.RepairInstructionId = Guid.NewGuid();
                RepairInstructionService.CreateRecord(model.RepairInstructionViewModel.RepairInstruction);
            }
            else
            {
                RepairInstructionService.UpdateRecord(model.RepairInstructionViewModel.RepairInstruction);
            }
            RepairInstructionService.SaveChanges();

            DapperService.SetRepairHeaderStatus(ConfigurationService.GetConnectionString("Default"), model.RepairHeader.RepairHeaderId);

            return RedirectToAction("RepairSummary", "Repair", new { RepairHeaderId = model.RepairHeader.RepairHeaderId });
        }
    }
}
