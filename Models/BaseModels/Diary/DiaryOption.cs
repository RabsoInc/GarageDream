using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Diary
{
    public class DiaryOption
    {
        [Key]
        public Guid DiaryOptionId { get; set; }
        public int DiaryNoticeForwardDays { get; set; }
    }
}
