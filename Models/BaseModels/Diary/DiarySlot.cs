using Models.BaseModels.Repair;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Diary
{
    public class DiarySlot
    {
        [Key]
        public Guid DiarySlotId { get; set; }

        [Required]
        public DiaryWorkingDate DiaryWorkingDate { get; set; }

        [Required]
        public WorkArea WorkArea { get; set; }

        [Required]
        public int UnitNumber { get; set; }

        public RepairInstruction RepairInstruction { get; set; }
    }
}
