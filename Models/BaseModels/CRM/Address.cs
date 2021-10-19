using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.CRM
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [MaxLength(150)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [MaxLength(150)]
        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

        [MaxLength(150)]
        [Display(Name = "Address Line 4")]
        public string AddressLine4 { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

    }
}
