using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.League.Contracts.ViewModels;

namespace VolleyballLeagueManagement.League.Domain.Handlers
{
    public class SetsRatioRuleHandler : OrderRuleHandler
    {
        public override void Handle(OrderRules rule, ref ICollection<TeamInTableViewModel> teamsStats)
        {
            if (rule == OrderRules.SetsRatio)
            {
                var teamInTableViewModels = teamsStats.OrderByDescending(t => t.SetsRatio);
                teamsStats = teamInTableViewModels.ToList();
            }
            else if (Successor != null)
            {
                Successor.Handle(rule, ref teamsStats);
            }
        }
    }
}
