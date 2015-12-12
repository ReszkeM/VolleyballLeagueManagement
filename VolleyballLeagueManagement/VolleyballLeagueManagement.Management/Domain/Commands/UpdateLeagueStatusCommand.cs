using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateLeagueStatusCommand : ICommand
    {
        public int LeagueId { get; set; }

        public int Status { get; set; }
    }
}
