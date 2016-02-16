using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.Common.Enums
{
    public enum LeagueStatus
    {
        [Display(Name = "Oczekuje na drużyny")]
        WaitingForTeams,
        [Display(Name = "Oczekuje na rozpoczęcie")]
        WaitingForStart,
        [Display(Name = "W trakcie")]
        InProgress,
        [Display(Name = "Zawieszona")]
        Suspended,
        [Display(Name = "Zakończona")]
        Ended
    }
}
