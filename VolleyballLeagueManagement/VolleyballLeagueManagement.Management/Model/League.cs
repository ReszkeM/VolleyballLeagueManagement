using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Model
{
    public class League
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public int RegulationsId { get; set; }

        public int OrganizerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AdditionalInformations { get; set; }

        public LeagueStatus Status { get; set; }


        public virtual SportsHall SportsHall { get; set; }

        public virtual Regulations Regulations { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<LeagueNote> Messages { get; set; }


        public void UpdateStatus(int status)
        {
            this.Status = (LeagueStatus) status;
        }
    }
}
