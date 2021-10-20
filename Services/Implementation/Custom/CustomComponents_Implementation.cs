using Models.ComponentModels;
using Services.Interfaces.Custom;

namespace Services.Implementation.Custom
{
    public class CustomComponents_Implementation : ICustomComponents
    {
        private readonly GarageDreamDbContext db;

        public CustomComponents_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public TitleComponentModel CreateTitle(string TitleText, bool ActionButtonNeeded = false, string ActionText = null, string Controller = null, string Action = null)
        {
            TitleComponentModel model = new TitleComponentModel
            {
                TitleText = TitleText,
                ActionButtonNeeded = ActionButtonNeeded,
                ActionText = ActionText,
                Controller = Controller,
                Action = Action
            };
            return model;
        }
    }
}
