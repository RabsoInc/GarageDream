using Models.BaseModels.CRM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class ContactDetailsViewModel
    {
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public CustomerContactDetail CustomerContactDetail { get; set; }

        [Required]
        public List<CustomerContactDetail> AllCustomerContactDetails { get; set; }
    }
}
