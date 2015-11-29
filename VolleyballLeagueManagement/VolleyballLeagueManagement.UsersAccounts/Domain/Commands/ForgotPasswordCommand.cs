using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class ForgotPasswordCommand : ICommand
    {
        public string Email { get; set; }
    }
}
