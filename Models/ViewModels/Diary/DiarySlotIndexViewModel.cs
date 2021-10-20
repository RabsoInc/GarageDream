using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Diary
{
    public class DiarySlotIndexViewModel
    {
        [Required]
        public DiarySlotFilterViewModel DiarySlotFilters { get; set; }

        [Required]
        public List<DiarySlotViewModel> DiarySlots { get; set; }

        public DiarySlotAdjustmentViewModel DiarySlotAdjustment { get; set; }


    }
}
