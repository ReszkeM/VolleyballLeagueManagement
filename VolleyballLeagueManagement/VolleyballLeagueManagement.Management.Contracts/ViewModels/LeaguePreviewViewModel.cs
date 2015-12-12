using System;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class LeaguePreviewViewModel
    {
        public int LeagueId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public LeagueStatus Status { get; set; }

        public int ApprovedTeams { get; set; }

        public int TeamsLimit { get; set; }

        public DateTime ApplicationDeadline { get; set; }

        public DateTime StartTime { get; set; }
    }
}
