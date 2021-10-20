using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Diary
{
    public class DiarySlotViewModel
    {

        [Required]
        public DateTime WorkingDate { get; set; }

        [Required]
        [Display(Name = "Work Area")]
        public string WorkAreaDescription { get; set; }

        [Required]
        public int BookedSlots { get; set; }

        [Required]
        public int AvailableSlots { get; set; }
    }
}
