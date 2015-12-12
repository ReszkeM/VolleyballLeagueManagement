using System;
using System.Collections.Generic;

namespace VolleyballLeagueManagement.League.Model
{
    public class Round
    {
        public int Id { get; set; }

        public int CalendarId { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }


        public virtual Calendar Calendar { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
