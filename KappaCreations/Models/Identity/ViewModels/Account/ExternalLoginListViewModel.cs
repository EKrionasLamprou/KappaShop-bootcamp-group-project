using System.ComponentModel.DataAnnotations;

namespace KappaCreations.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}