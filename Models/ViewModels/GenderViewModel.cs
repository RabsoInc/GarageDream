using Models.BaseModels.CRM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class GenderViewModel
    {
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public List<Gender> AllGenders { get; set; }
    }
}
