using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.League.Domain.Commands
{
    public class GenerateCalendarCommand : ICommand
    {
        public int LeagueId { get; set; }
    }
}
