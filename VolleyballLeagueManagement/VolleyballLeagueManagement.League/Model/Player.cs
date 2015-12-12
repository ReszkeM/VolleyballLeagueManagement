using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.League.Model
{
    public class Player
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCapitan { get; set; }

        public Position Position { get; set; }


        public virtual Team Team { get; set; }
    }
}
