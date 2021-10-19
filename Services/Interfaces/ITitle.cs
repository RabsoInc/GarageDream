using Models.BaseModels.CRM;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ITitle : IGenericOperations_PK_GUID<Title>
    {
        public IEnumerable<Title> GenerateDropDowns();
    }
}
