using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.CRM
{
    public class ContactMethodType
    {
        [Key]
        public Guid ContactMethodTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Contact Method")]
        public string ContactMethodTypeDescription { get; set; }
    }
}
