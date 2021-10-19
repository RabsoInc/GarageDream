using System;
using System.ComponentModel.DataAnnotations;

namespace Models.InternalViewModels
{
    public class CustomerIndexInternalModel
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
