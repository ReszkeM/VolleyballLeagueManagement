using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        [EmailAddress(ErrorMessage = "Podany adres email jest nieprawidłowy")]
        public string Email { get; set; }
    }
}
