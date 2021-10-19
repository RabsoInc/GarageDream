using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Vehicles
{
    public class VehicleMake
    {
        [Key]
        public Guid VehicleMakeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Vehicle Make")]
        public string VehicleMakeDescription { get; set; }
    }
}
