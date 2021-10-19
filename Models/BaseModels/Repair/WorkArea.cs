using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Repair
{
    public class WorkArea
    {
        [Key]
        public Guid WorkAreaId { get; set; }

        [Required]
        [Display(Name = "Work Area")]
        public string WorkAreaDescription { get; set; }

        [Required]
        public int DefaultUnits { get; set; }


    }
}
