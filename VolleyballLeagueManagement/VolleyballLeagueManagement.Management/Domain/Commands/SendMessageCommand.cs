using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class SendMessageCommand : ICommand
    {
        public int From { get; set; } // TeamId

        public int To { get; set; } // LeagueId

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
