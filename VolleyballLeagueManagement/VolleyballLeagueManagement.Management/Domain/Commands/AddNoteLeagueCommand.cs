using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class AddNoteLeagueCommand : ICommand
    {
        public int LeagueId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
