using Models.BaseModels.CRM;
using System.ComponentModel.DataAnnotations;

namespace Models.ComponentModels
{
    public class CustomerCreationStageComponentModel
    {
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public bool HasContactDetails { get; set; }

        [Required]
        public bool HasAddress { get; set; }

        [Required]
        public bool HasVehicals { get; set; }

        [Required]
        public int CountOfNotes { get; set; }
    }
}
