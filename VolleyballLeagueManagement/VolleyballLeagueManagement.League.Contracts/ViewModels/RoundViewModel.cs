using System;
using System.Collections.Generic;

namespace VolleyballLeagueManagement.League.Contracts.ViewModels
{
    public class RoundViewModel
    {
        public int RoundId { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public ICollection<GameViewModel> Games { get; set; }
    }
}
