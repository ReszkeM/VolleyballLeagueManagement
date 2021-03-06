﻿using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.Common.Enums
{
    public enum Days
    {
        [Display(Name = "Poniedziałek")]
        Monday,
        [Display(Name = "Wtorek")]
        Tuesday,
        [Display(Name = "Środa")]
        Wednesday,
        [Display(Name = "Czwartek")]
        Thursday,
        [Display(Name = "Piątek")]
        Friday,
        [Display(Name = "Sobota")]
        Saturday,
        [Display(Name = "Niedziela")]
        Sunday
    }
}
