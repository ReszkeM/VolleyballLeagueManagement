using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class TeamPreviewViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TeamStatus Status { get; set; }

        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }
    }
}
