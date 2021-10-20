using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Repair
{
    public class RepairStatus
    {
        [Key]
        public Guid RepairStatusId { get; set; }

        [Required]
        [Display(Name = "Precedence Order")]
        public int PrecedenceOrder { get; set; }

        [Required]
        [Display(Name = "Repair Status")]
        [MaxLength(100)]
        public string RepairStatusDescription { get; set; }
    }
}