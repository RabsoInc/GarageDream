using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Diary
{
    public class DiaryWorkingDate
    {
        [Key]
        public Guid DiaryWorkingDateId { get; set; }

        [Required]
        public DateTime WorkingDate { get; set; }

        [Required]
        public bool Processed { get; set; }
    }
}
