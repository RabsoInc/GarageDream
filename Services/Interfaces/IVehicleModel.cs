using Models.BaseModels;
using Models.BaseModels.Vehicles;
using Services.Templates;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVehicleModel : IGenericOperations_PK_GUID<VehicleModel>
    {
        public IEnumerable<VehicleModel> GenerateDropDowns();
        public List<VehicleModel> ReturnAllRecordsByVehicleMake(Guid VehicleMakeId);
    }
}
