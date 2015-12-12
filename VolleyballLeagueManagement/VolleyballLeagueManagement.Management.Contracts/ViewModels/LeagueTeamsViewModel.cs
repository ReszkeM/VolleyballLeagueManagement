using System.Collections.Generic;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class LeagueTeamsViewModel
    {
        public int LeagueId { get; set; }

        public ICollection<TeamPreviewViewModel> Teams { get; set; }

        public ICollection<TeamPreviewViewModel> TeamsToApprove { get; set; }
    }
}
