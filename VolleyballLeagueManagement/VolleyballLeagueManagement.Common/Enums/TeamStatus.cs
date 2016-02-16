using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.Common.Enums
{
    public enum TeamStatus
    {
        [Display(Name = "Szuka ligi")]
        LookingForLeague,
        [Display(Name = "Oczekuje na zatwierdzenie")]
        WaitingForApprove,
        [Display(Name = "Potwierdzona")]
        Approved,
        [Display(Name = "Odrzucona")]
        Rejected,
        [Display(Name = "W trakcie rozgrywek")]
        InLeague,
        [Display(Name = "Usunięta z rozgrywek")]
        Removed
    }
}
