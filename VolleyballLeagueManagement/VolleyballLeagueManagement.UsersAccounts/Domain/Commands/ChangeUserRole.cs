using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class ChangeUserRole : ICommand
    {
        public int UserId { get; set; }

        public int RoleValue { get; set; }
    }
}
