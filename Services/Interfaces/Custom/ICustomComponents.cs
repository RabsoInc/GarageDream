using Models.ComponentModels;

namespace Services.Interfaces.Custom
{
    public interface ICustomComponents
    {
        public TitleComponentModel CreateTitle(string TitleText, bool ActionButtonNeeded = false, string ActionText = null, string Controller = null, string Action = null);
    }
}
