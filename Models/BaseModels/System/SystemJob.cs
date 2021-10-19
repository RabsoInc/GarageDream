using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.System
{
    public class SystemJob
    {
        [Key]
        public Guid SystemJobId { get; set; }

        [Required]
        [Display(Name = "System Job")]
        [MaxLength(150)]
        public string SystemJobDescription { get; set; }

        [Required]
        [Display(Name = "Run Job On Start Up")]
        public bool AutoRunOnStartUp { get; set; }

        [Required]
        [Display(Name = "Stored Procedure Name")]
        [MaxLength(150)]
        public string ProcedureName { get; set; }
    }
}
