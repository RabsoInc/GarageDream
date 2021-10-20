using Models.ViewModels.Generic;
using Services.Interfaces.Generic;
using System.Collections.Generic;

namespace Services.Implementation.Generic
{
    public class StaticLists_Implementation : IStaticLists
    {
        public List<StaticListViewModel> YesNo()
        {
            List<StaticListViewModel> result = new();
            result.Add(new StaticListViewModel { DbValue = "true", FriendlyName = "Yes" });
            result.Add(new StaticListViewModel { DbValue = "false", FriendlyName = "No" });
            return result;
        }
    }
}
