using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Repair
{
    public class RepairCustomSelectViewModel
    {
        [Required]
        public Guid RepairId { get; set; }

        [Required]
        public string SelectDescription { get; set; }
    }
}
