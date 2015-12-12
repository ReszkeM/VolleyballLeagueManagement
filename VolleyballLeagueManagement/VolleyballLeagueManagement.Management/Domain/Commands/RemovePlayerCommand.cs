using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class RemovePlayerCommand : ICommand
    {
        public int PlayerId { get; set; }
    }
}
