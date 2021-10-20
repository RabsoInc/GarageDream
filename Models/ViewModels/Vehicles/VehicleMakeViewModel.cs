using Models.BaseModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Vehicles
{
    public class VehicleMakeViewModel
    {
        [Required]
        public VehicleMake VehicleMake { get; set; }

        [Required]
        public List<VehicleMake> AllVehicleMakes { get; set; }
    }
}
