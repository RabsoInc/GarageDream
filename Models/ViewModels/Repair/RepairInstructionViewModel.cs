using Models.BaseModels.Repair;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Repair
{
    public class RepairInstructionViewModel
    {
        [Required]
        public RepairInstruction RepairInstruction { get; set; }

        [Required]
        public List<RepairInstruction> AllRepairInstructions { get; set; }
    }
}
