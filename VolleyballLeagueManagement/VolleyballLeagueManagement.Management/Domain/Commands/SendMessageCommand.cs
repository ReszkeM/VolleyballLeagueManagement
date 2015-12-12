using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class SendMessageCommand : ICommand
    {
        public int From { get; set; }

        public int To { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
