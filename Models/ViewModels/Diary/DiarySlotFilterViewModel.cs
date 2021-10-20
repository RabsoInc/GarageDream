using Models.BaseModels.Repair;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Diary
{
    public class DiarySlotFilterViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public WorkArea WorkArea { get; set; }
    }
}
