namespace VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string NewPasswordRepeat { get; set; }
    }
}
