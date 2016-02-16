using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Login { get; set; }

        [DisplayName("Hasło")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Password { get; set; }

        [DisplayName("Zapamiętaj mnie*")]
        public bool RememberMe { get; set; }
    }
}
