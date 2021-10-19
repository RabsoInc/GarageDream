using Models.BaseModels.Repair;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class WorkAreaViewModel
    {
        [Required]
        public WorkArea WorkArea { get; set; }

        [Required]
        public List<WorkArea> AllWorkAreas { get; set; }
    }
}
