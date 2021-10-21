using Models.BaseModels.Repair;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces.Repair
{
    public interface IRepairCategory : IGenericOperations_PK_GUID<RepairCategory>
    {
        public IEnumerable<RepairCategory> GenerateDropDowns();
    }
}
