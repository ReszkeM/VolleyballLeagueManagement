using System;
namespace VolleyballLeagueManagement.Management.Model
{
    public class Regulations
    {
        public int Id { get; set; }

        public int LeagueId { get; set; }

        public int DocumentId { get; set; }

        public int TableOrderRulesId { get; set; }

        public int TeamsLimit { get; set; }

        public int PlayersLimit { get; set; }

        public int EntryFee { get; set; }

        public bool Playoffs { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime ApplicationDeadline { get; set; }


        public virtual League League { get; set; }

        public virtual Document Document { get; set; }

        public virtual TableOrderRules TableOrderRules { get; set; }
    }
}
