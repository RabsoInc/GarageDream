using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Diary
{
    public class DiarySlotAdjustmentViewModel
    {
        [Display(Name = "Work Area Description")]
        public string WorkArea { get; set; }

        [Display(Name = "Date")]
        public string WorkingDate { get; set; }

        [Display(Name ="Revised Slots")]
        public int RevisedSlots { get; set; }
    }
}
