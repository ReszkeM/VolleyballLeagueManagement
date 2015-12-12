using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class CreateTeamCommand : ICommand
    {
        public int ManagerId { get; set; }

        public string Name { get; set; }

        // Coach
        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public int CoachAge { get; set; }

        public string CoachPhone { get; set; }

        public string CoachEmail { get; set; }
    }
}
