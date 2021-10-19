using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Vehicles
{
    public class FuelType
    {
        [Key]
        public Guid FuelTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Fuel Type")]
        public string FuelTypeDescription { get; set; }
    }
}
