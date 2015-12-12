using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class AddPlayerCommand : ICommand
    {
        public int TeamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCapitan { get; set; }

        public int Age { get; set; }

        public int Growth { get; set; }

        public int PositionValue { get; set; }
    }
}
