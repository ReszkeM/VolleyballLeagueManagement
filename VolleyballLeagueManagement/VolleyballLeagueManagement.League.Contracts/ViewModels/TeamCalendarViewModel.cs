using System.Collections.Generic;

namespace VolleyballLeagueManagement.League.Contracts.ViewModels
{
    public class TeamCalendarViewModel
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public ICollection<GameViewModel> Games { get; set; }
    }
}
