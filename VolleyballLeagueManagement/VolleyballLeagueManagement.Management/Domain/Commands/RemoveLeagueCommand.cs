using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class RemoveLeagueCommand : ICommand
    {
        public int Id { get; set; }
    }
}
