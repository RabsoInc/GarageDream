using Models.BaseModels.CRM;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Vehicles
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Make")]
        public VehicleMake VehicleMake { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Model")]
        public VehicleModel VehicleModel { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Registration")]
        public string RegistrationNumber { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public FuelType FuelType { get; set; }
    }
}
