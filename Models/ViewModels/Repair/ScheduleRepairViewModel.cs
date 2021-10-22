using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Repair
{
    public class ScheduleRepairViewModel
    {
        [Display(Name = "Units required (30 min blocks)")]
        [Range(1, 25)]
        public int UnitsRequired { get; set; }

        public DateTime SelectedDate { get; set; }

        public Guid RepairInstructionId { get; set; }

        public string WorkAreaDescription { get; set; }
    }
}
