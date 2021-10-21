using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Repair
{
    public class RepairCategory
    {
        [Key]
        public Guid RepairCategoryId { get; set; }

        [Required]
        [Display(Name = "Repair Category")]
        [MaxLength(100)]
        public string RepairCategoryDescription { get; set; }

    }
}
