using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.Common.Enums
{
    public enum Role
    {
        [Display(Name = "Organizator")]
        LeagueManager,
        //LeagueContributor,
        [Display(Name = "Kapitan")]
        TeamManager,
        //TeamContributor
    }
}
