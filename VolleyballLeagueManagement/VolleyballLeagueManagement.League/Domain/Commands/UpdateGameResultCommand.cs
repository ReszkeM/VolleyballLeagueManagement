using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.League.Contracts.ViewModels;

namespace VolleyballLeagueManagement.League.Domain.Commands
{
    public class UpdateGameResultCommand : ICommand
    {
        public GameViewModel Game { get; set; }
    }
}
