using System.Collections.Generic;

namespace VolleyballLeagueManagement.League.Model
{
    public class Calendar
    {
        public int Id { get; set; }

        public int LeagueId { get; set; }


        public virtual League League { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }
    }
}
