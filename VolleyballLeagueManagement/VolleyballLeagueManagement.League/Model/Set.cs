using System;

namespace VolleyballLeagueManagement.League.Model
{
    public class Set
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }

        public TimeSpan Time { get; set; }

        public int FirstTeamPoints { get; set; }

        public int SecondTeamPoints { get; set; }


        public virtual Game Game { get; set; }
    }
}
