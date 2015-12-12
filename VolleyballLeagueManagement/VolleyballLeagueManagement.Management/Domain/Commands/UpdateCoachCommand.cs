using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateCoachCommand : ICommand
    {
        public int TeamId { get; set; }

        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public int CoachAge { get; set; }

        public string CoachPhone { get; set; }

        public string CoachEmail { get; set; }
    }
}
