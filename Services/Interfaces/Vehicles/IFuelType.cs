using Models.BaseModels.Vehicles;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IFuelType : IGenericOperations_PK_GUID<FuelType>
    {
        public IEnumerable<FuelType> GenerateDropDowns();
    }
}
