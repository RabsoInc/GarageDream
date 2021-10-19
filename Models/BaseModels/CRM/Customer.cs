using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.CRM
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        public Title Title { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public Address Address { get; set; }

    }
}
