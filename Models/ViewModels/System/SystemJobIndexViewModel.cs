using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.System
{
    public class SystemJobIndexViewModel
    {
        [Required]
        public Guid SystemJobId { get; set; }

        [Required]
        public string SystemJobDescription { get; set; }

        [Required]
        public string ProcedureName { get; set; }

        [Required]
        public bool AutoRunOnStartUp { get; set; }  

        [Required]
        public DateTime DateLastExecuted { get; set; }
    }
}
