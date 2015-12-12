using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateTeamStatusCommand : ICommand
    {
        public int LeagueId { get; set; }

        public int TeamId { get; set; }

        public bool Accept { get; set; }
    }
}
