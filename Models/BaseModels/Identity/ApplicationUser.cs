using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Models.BaseModels.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }
    }
}
