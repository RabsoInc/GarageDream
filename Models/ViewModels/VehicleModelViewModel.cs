using Models.BaseModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class VehicleModelViewModel
    {
        [Required]
        public VehicleModel VehicleModel { get; set; }

        [Required]
        public List<VehicleModel> AllVehicleModels { get; set; }
    }
}
