using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class LeaveLeagueCommand : ICommand
    {
        public int TeamId { get; set; }
    }
}
