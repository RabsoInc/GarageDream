using Models.BaseModels.Repair;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Repair
{
    public class RepairViewModel
    {
        [Required]
        public RepairHeader RepairHeader { get; set; }

        [Required]
        public string RepairHeaderStatusPerc { get; set; }

        [Required]
        public RepairCategoryViewModel RepairCategoryViewModel { get; set; }

        [Required]
        public RepairInstructionViewModel RepairInstructionViewModel { get; set; }

        [Required]
        public ScheduleRepairViewModel ScheduleRepair { get; set; }
    }
}
