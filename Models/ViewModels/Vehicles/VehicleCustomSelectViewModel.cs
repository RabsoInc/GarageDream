using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Vehicles
{
    public class VehicleCustomSelectViewModel
    {
        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public string SelectDescription { get; set; }
    }
}
