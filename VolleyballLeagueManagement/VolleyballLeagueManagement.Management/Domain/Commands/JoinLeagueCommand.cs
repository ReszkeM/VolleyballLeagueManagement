using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class JoinLeagueCommand : ICommand
    {
        public int TeamId { get; set; }

        public int LeagueId { get; set; }
    }
}
