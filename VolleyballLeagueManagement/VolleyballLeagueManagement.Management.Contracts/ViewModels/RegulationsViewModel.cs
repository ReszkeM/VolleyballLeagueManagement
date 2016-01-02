using System;
using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class RegulationsViewModel
    {
        public int Id { get; set; }

        public int LeagueId { get; set; }

        public int DocumentId { get; set; }

        public string LeagueName { get; set; }

        public int TeamsLimit { get; set; }

        public int PlayersLimit { get; set; }

        public int EntryFee { get; set; }

        public bool Playoffs { get; set; }

        public Days Day { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime ApplicationDeadline { get; set; }

        public ICollection<OrderRules> TableOrderRules { get; set; }
    }
}
