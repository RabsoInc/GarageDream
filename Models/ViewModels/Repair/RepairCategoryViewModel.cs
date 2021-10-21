using Models.BaseModels.Repair;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Repair
{
    public class RepairCategoryViewModel
    {
        [Required]
        public RepairCategory RepairCategory { get; set; }

        [Required]
        public List<RepairCategory> AllRepairCategories { get; set; }
    }
}
