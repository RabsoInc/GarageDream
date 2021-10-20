using Models.BaseModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Vehicles
{
    public class FuelTypeViewModel
    {
        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public List<FuelType> AllFuelTypes { get; set; }
    }
}
