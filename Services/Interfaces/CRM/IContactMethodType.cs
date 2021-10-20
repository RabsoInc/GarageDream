using Models.BaseModels.CRM;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces.CRM
{
    public interface IContactMethodType : IGenericOperations_PK_GUID<ContactMethodType>
    {
        public IEnumerable<ContactMethodType> GenerateDropDowns();
    }
}
