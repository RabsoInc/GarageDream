using Models.BaseModels.Repair;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
