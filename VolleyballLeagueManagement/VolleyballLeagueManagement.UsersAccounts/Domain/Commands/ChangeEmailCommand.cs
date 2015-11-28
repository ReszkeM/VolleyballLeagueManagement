using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class ChangeEmailCommand : ICommand
    {
        public int UserId { get; set; }

        public string OldEmail { get; set; }

        public string NewEmail { get; set; }

        public string NewEmailRepeat { get; set; }
    }
}
