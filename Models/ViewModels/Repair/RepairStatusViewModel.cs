using Models.BaseModels.Repair;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Repair
{
    public class RepairStatusViewModel
    {
        [Required]
        public RepairStatus RepairStatus { get; set; }

        [Required]
        public List<RepairStatus> AllRepairStatuses { get; set; }
    }
}
