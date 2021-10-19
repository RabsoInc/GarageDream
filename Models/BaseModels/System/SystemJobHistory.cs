using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.System
{
    public class SystemJobHistory
    {
        [Key]
        public Guid SystemJobHistoryId { get; set; }

        [Required]
        public SystemJob SystemJob { get; set; }

        [Required]
        public DateTime DateExecuted { get; set; }

        [Required]
        public bool AutoExecuted { get; set; }
    }
}
