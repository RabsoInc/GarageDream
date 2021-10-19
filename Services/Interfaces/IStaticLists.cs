using Models.ViewModels;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IStaticLists
    {
        public List<StaticListViewModel> YesNo();
    }
}
