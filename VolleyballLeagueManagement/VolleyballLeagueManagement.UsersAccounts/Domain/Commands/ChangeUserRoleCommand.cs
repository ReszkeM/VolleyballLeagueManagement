using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class ChangeUserRoleCommand : ICommand
    {
        public int UserId { get; set; }

        public int Role { get; set; }
    }
}
