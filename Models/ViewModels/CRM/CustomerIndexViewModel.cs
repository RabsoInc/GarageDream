using Models.InternalViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.CRM
{
    public class CustomerIndexViewModel
    {
        [Required]
        public IEnumerable<CustomerIndexInternalModel> Customers { get; set; }
    }
}
