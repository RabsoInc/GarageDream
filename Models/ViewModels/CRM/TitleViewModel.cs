using Models.BaseModels.CRM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.CRM
{
    public class TitleViewModel
    {
        [Required]
        public Title Title { get; set; }

        [Required]
        public List<Title> AllTitles { get; set; }
    }
}
