using Models.BaseModels.CRM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class ContactMethodTypeViewModel
    {
        [Required]
        public ContactMethodType ContactMethodType { get; set; }

        [Required]
        public List<ContactMethodType> AllContactMethodType { get; set; }
    }
}
