using Microsoft.AspNetCore.Mvc;
using Models.ComponentModels;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Web.Components
{
    [ViewComponent]
    public class TitleViewComponent : ViewComponent
    {
        private readonly ICustomComponents CustomComponentService;

        public TitleViewComponent(ICustomComponents CustomComponentService)
        {
            this.CustomComponentService = CustomComponentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string TitleText, bool ActionButtonNeeded, string Action, string Controller, string ActionText)
        {
            TitleComponentModel model = CustomComponentService.CreateTitle(TitleText, ActionButtonNeeded, ActionText, Controller, Action);
            return View(model);
        }
    }
}
