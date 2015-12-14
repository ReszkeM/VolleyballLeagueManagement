using System;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.League.Domain.Commands
{
    public class UpdateGameDateCommand : ICommand
    {
        public int GameId { get; set; }

        public DateTime NewDate { get; set; }
    }
}
