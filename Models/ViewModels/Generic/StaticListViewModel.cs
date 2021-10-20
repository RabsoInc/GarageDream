using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Generic
{
    public class StaticListViewModel
    {
        [Required]
        public string FriendlyName { get; set; }

        [Required]
        public string DbValue { get; set; }
    }
}
