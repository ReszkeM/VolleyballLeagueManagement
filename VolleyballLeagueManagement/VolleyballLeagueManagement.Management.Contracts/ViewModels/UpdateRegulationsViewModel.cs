using System;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class UpdateRegulationsViewModel
    {
        public int LeagueId { get; set; }

        public int TeamsLimit { get; set; }

        public int PlayersLimit { get; set; }

        public int EntryFee { get; set; }

        public bool Playoffs { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime ApplicationDeadline { get; set; }
    }
}
