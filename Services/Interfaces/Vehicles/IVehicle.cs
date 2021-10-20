using Models.BaseModels.Vehicles;
using Models.ViewModels.Vehicles;
using Services.Templates;
using System;
using System.Collections.Generic;

namespace Services.Interfaces.Vehicles
{
    public interface IVehicle : IGenericOperations_PK_GUID<Vehicle>
    {
        public List<Vehicle> ReturnAllRecordsByCustomerId(Guid CustomerId);
        public List<VehicleCustomSelectViewModel> ReturnAllRecordsByCustomerId_CustomDisplay(Guid CustomerId);
    }
}
