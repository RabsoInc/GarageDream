
using Models.BaseModels.CRM;
using Models.BaseModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Vehicles
{
    public class VehicleViewModel
    {
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        [Required]
        public List<Vehicle> AllVehicles { get; set; }
    }
}
