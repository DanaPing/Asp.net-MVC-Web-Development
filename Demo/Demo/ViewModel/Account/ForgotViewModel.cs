using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModel.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}