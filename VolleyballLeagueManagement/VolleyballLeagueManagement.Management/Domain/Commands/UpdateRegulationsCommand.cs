using System;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateRegulationsCommand : ICommand
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
