using System;

namespace VolleyballLeagueManagement.League.Contracts.ViewModels
{
    public class SetViewModel
    {
        public int SetId { get; set; }

        public int Number { get; set; }

        public TimeSpan Duration { get; set; }

        public int FirstTeamPoints { get; set; }

        public int SecondTeamPoints { get; set; } 
    }
}
