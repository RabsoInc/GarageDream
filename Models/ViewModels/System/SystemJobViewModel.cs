using Models.BaseModels.System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.System
{
    public class SystemJobViewModel
    {
        [Required]
        public SystemJob SystemJob { get; set; }

        [Required]
        public List<SystemJobIndexViewModel> AllSystemJobs { get; set; }
    }
}
