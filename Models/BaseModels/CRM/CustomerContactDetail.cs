using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.CRM
{
    public class CustomerContactDetail
    {
        [Key]
        public Guid CustomerContactDetailId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public ContactMethodType ContactMethodType { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Contact details value")]
        public string Value { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }
    }
}
