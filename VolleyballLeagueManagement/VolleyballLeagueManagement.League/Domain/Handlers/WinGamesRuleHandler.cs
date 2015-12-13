using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.League.Contracts.ViewModels;

namespace VolleyballLeagueManagement.League.Domain.Handlers
{
    public class WinGamesRuleHandler : OrderRuleHandler
    {
        public override void Handle(OrderRules rule, ref ICollection<TeamInTableViewModel> teamsStats)
        {
            if (rule == OrderRules.WinGames)
            {
                var teamInTableViewModels = teamsStats.OrderByDescending(t => t.WinGames);
                teamsStats = teamInTableViewModels.ToList();
            }
            else if (Successor != null)
            {
                Successor.Handle(rule, ref teamsStats);
            }
        }
    }
}
