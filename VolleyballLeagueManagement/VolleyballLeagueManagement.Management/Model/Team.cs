using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Model
{
    public class Team
    {
        public int Id { get; set; }

        public int ManagerId { get; set; }

        public int? LeagueId { get; set; }

        public int CoachId { get; set; }

        public string Name { get; set; }

        public TeamStatus Status { get; set; }


        public virtual League League { get; set; }

        public virtual League LeagueToApprove { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual ICollection<Player> Players { get; set; }


        public void LeaveLeague(League league)
        {
            league.Teams.Remove(this);
            this.League = null;
            this.LeagueId = null;
        }
    }
}
