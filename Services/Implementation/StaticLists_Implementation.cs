using Models.ViewModels;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Implementation
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
