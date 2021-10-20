using Models.BaseModels.Vehicles;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Repair
{
    public class RepairHeader
    {
        [Key]
        public Guid RepairHeaderId { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        [Required]
        public RepairStatus RepairStatus { get; set; }

        [Required]
        public DateTime JobBooked { get; set; }
    }
}
