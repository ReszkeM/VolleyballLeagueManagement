using System;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.League.Model
{
    public class Regulations
    {
        public int Id { get; set; }

        public int LeagueId { get; set; }

        public int TableOrderRulesId { get; set; }

        public bool Playoffs { get; set; }

        public Days Days { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


        public virtual League League { get; set; }

        public virtual TableOrderRules TableOrderRules { get; set; }
    }
}
