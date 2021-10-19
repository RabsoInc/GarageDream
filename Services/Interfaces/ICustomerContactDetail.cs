
using Models.BaseModels.CRM;
using Services.Templates;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICustomerContactDetail : IGenericOperations_PK_GUID<CustomerContactDetail>
    {
        public List<CustomerContactDetail> ReturnAllRecords(Guid CustomerId);
    }
}
