using Models.BaseModels.CRM;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces.CRM
{
    public interface IGender : IGenericOperations_PK_GUID<Gender>
    {
        public IEnumerable<Gender> GenerateDropDowns();
    }
}
