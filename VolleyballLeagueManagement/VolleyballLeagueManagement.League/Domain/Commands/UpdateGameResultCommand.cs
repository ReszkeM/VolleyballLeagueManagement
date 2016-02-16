using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.League.Contracts.ViewModels;

namespace VolleyballLeagueManagement.League.Domain.Commands
{
    public class UpdateGameResultCommand : ICommand
    {
        public int GameId { get; set; }

        public ICollection<SetViewModel> Sets { get; set; }
    }
}
