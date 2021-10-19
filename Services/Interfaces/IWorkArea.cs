using Models.BaseModels.Repair;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IWorkArea : IGenericOperations_PK_GUID<WorkArea>
    {
        public IEnumerable<WorkArea> GenerateDropDowns();
    }
}
