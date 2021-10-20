using Models.InternalViewModels;
using Models.ViewModels.Repair;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.CRM
{
    public class CustomerIndexViewModel
    {
        [Required]
        public IEnumerable<CustomerIndexInternalModel> Customers { get; set; }

        [Required]
        public CreateRepairFromCustomerIndexViewModel NewRepair { get; set; }

        public Guid RepairHeaderId { get; set; }
    }
}
