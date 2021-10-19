using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.CRM
{
    public class Gender
    {
        [Key]
        public Guid GenderId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Gender")]
        public string GenderDescription { get; set; }
    }
}