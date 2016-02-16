using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.Common.Enums
{
    public enum OrderRules
    {
        [Display(Name = "Brak")]
        None,
        [Display(Name = "Punkty")]
        Points,
        [Display(Name = "Wygrane spotkania")]
        WinGames,
        [Display(Name = "Stosunek setów")]
        SetsRatio,
        [Display(Name = "Stosunek małych punktów")]
        SmallPointsRatio,
        [Display(Name = "Bezpośredni pojedynek")]
        DirectMatch
    }
}
