using Models.BaseModels.Vehicles;
using Services.Templates;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVehicle : IGenericOperations_PK_GUID<Vehicle>
    {
        public List<Vehicle> ReturnAllRecordsByCustomerId(Guid CustomerId);
    }
}
