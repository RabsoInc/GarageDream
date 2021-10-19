using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.CRM
{
    public class Title
    {
        [Key]
        public Guid TitleId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string TitleDescription { get; set; }
    }
}