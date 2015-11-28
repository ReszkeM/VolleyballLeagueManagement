using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class RemoveUserCommand : ICommand
    {
        public int Id { get; set; }
    }
}
