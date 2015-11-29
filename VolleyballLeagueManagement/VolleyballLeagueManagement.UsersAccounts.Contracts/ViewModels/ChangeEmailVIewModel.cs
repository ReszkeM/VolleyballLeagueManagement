namespace VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels
{
    public class ChangeEmailViewModel
    {
        public int UserId { get; set; }

        public string OldEmail { get; set; }

        public string NewEmail { get; set; }

        public string NewEmailRepeat { get; set; }
    }
}
