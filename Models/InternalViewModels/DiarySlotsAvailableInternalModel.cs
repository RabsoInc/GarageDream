using System;
using System.ComponentModel.DataAnnotations;

namespace Models.InternalViewModels
{
    public class DiarySlotsAvailableInternalModel
    {
        [DataType(DataType.Date)]
        public string AvailableDate { get; set; }
    }
}
