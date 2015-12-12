using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class RemoveTeamCommand : ICommand
    {
        public int Id { get; set; }
    }
}
