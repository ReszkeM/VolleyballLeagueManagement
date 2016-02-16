using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.League.Model
{
    public class League
    {
        public int Id { get; set; }

        public int RegulationsId { get; set; }

        public int OrganizerId { get; set; }

        public int AddressId { get; set; }

        public int CalendarId { get; set; }

        public string Name { get; set; }

        public LeagueStatus Status { get; set; }


        public virtual Regulations Regulations { get; set; }

        public virtual Calendar Calendar { get; set; }

        public virtual ICollection<Team> Teams { get; set; } 
    }
}
