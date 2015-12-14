using System;

namespace VolleyballLeagueManagement.League.Contracts.ViewModels
{
    public class UpdateGameDateViewModel
    {
        public int GameId { get; set; }

        public DateTime NewDate { get; set; }
    }
}
