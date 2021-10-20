using Models.BaseModels.Vehicles;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVehicleMake : IGenericOperations_PK_GUID<VehicleMake>
    {
        public IEnumerable<VehicleMake> GenerateDropDowns();
    }
}
