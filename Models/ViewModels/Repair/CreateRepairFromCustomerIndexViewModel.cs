using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Repair
{
    public class CreateRepairFromCustomerIndexViewModel
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid VehicleId { get; set; }
    }
}
