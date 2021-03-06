﻿using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCapitan { get; set; }

        public int Age { get; set; }

        public int Growth { get; set; }

        public Position Position { get; set; }
    }
}
