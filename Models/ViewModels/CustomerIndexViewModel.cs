using Models.InternalViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class CustomerIndexViewModel
    {
        [Required]
        public IEnumerable<CustomerIndexInternalModel> Customers { get; set; }
    }
}
