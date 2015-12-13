using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.League.Model
{
    public class Team
    {
        public int Id { get; set; }

        public int? LeagueId { get; set; }

        public int ManagerId { get; set; }

        public string Name { get; set; }
        
        public TeamStatus Status { get; set; }


        public virtual League League { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
