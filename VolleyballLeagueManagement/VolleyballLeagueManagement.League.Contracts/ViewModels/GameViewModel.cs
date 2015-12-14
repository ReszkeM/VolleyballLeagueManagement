using System;
using System.Collections.Generic;

namespace VolleyballLeagueManagement.League.Contracts.ViewModels
{
    public class GameViewModel
    {
        public int GameId { get; set; }

        public int FirstTeamId { get; set; }

        public int SecondTeamId { get; set; }

        public int PlayerId { get; set; }

        public string FirstTeamName { get; set; }

        public string SecondTeamName { get; set; }

        public string PlayerName { get; set; }

        public DateTime Date { get; set; }

        public ICollection<SetViewModel> Sets { get; set; } 
    }
}
