using Models.BaseModels.Repair;
using Models.ViewModels.Repair;
using Services.Templates;
using System;
using System.Collections.Generic;

namespace Services.Interfaces.Repair
{
    public interface IRepairHeader : IGenericOperations_PK_GUID<RepairHeader>
    {
        public  List<RepairCustomSelectViewModel> ReturnAllRecordsByCustomerId_CustomDisplay(Guid CustomerId);
    }
}
