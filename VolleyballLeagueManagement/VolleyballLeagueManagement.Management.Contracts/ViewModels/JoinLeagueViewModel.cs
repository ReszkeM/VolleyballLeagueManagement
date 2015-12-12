using System.Collections.Generic;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class JoinLeagueViewModel
    {
        public int TeamId { get; set; }

        public int LeagueId { get; set; }

        public ICollection<LeaguePreviewViewModel> Leagues { get; set; }
    }
}
