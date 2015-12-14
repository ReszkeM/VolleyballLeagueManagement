using System.Collections.Generic;

namespace VolleyballLeagueManagement.League.Contracts.ViewModels
{
    public class CalendarViewModel
    {
        public int CalendarId { get; set; }

        public ICollection<RoundViewModel> Rounds { get; set; } 
    }
}
