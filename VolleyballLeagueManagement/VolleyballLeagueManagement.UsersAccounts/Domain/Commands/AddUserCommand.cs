using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class AddUserCommand : ICommand
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string PasswordRepeat { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }
    }
}
