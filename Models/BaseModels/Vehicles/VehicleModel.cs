using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Vehicles
{
    public class VehicleModel
    {
        [Key]
        public Guid VehicleModelId { get; set; }

        [Required]
        public VehicleMake VehicleMake { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Vehicle Model")]
        public string VehicleModelDescription { get; set; }
    }
}
