using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateSportsHallCommand : ICommand
    {
        public int LeagueId { get; set; }

        public string City { get; set; }

        public string Streat { get; set; }

        public int Number { get; set; }

        public string PostCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
