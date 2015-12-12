using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateLeagueInformationsCommand : ICommand
    {
        public int LeagueId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AdditionalInformations { get; set; }
    }
}
