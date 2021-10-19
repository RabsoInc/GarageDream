using System.ComponentModel.DataAnnotations;

namespace Models.ComponentModels
{
    public class TitleComponentModel
    {
        [Required]
        public string TitleText { get; set; }

        [Required]
        public bool ActionButtonNeeded { get; set; }

        public string ActionText { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}
