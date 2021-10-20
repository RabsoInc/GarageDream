using Models.ViewModels.Generic;
using System.Collections.Generic;

namespace Services.Interfaces.Generic
{
    public interface IStaticLists
    {
        public List<StaticListViewModel> YesNo();
    }
}
