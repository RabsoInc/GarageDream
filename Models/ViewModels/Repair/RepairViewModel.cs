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
    }
}
