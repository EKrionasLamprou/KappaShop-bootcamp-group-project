using System.ComponentModel.DataAnnotations;

namespace KappaCreations.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}