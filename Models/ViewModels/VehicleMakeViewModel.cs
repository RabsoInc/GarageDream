using Models.BaseModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class VehicleMakeViewModel
    {
        [Required]
        public VehicleMake VehicleMake { get; set; }

        [Required]
        public List<VehicleMake> AllVehicleMakes { get; set; }
    }
}
