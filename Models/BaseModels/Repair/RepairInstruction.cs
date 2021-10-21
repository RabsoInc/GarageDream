using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Repair
{
    public class RepairInstruction
    {
        [Key]
        public Guid RepairInstructionId { get; set; }

        [Required]
        public RepairHeader RepairHeader { get; set; }

        [Required]
        public RepairCategory RepairCategory { get; set; }

        [Required]
        public WorkArea WorkArea { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [MaxLength(100)]
        public string Comments { get; set; }

        public RepairStatus RepairStatus { get; set; }
    }
}
