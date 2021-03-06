using Models.BaseModels.Repair;
using Services.Templates;

namespace Services.Interfaces.Repair
{
    public interface IRepairStatus : IGenericOperations_PK_GUID<RepairStatus>
    {
        public string CalculateRepairStatusPerc(RepairStatus RepairStatus);
        public RepairStatus ReturnFirstStatus();
    }
}
