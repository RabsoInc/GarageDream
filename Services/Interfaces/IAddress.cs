using Models.BaseModels.CRM;
using Services.Templates;
using System;

namespace Services.Interfaces
{
    public interface IAddress : IGenericOperations_PK_GUID<Address>
    {
        public Address ReturnSingleRecordByCustomerId(Guid CustomerId);
    }
}
