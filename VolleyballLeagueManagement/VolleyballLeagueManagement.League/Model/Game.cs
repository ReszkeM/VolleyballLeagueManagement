using System;
using System.Collections.Generic;

namespace VolleyballLeagueManagement.League.Model
{
    public class Game
    {
        public int Id { get; set; }

        public int RoundId { get; set; }

        public int FirstTeamId { get; set; }

        public int SecondTeamId { get; set; }

        public int? MVPId { get; set; }

        public DateTime Date { get; set; }


        public virtual Team FirstTeam { get; set; }

        public virtual Team SecondTeam { get; set; }

        public virtual Player MVP { get; set; }

        public virtual ICollection<Set> Sets { get; set; } 
    }
}
