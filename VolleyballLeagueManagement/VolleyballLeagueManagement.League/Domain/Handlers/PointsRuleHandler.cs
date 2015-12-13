using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.League.Contracts.ViewModels;

namespace VolleyballLeagueManagement.League.Domain.Handlers
{
    public class PointsRuleHandler : OrderRuleHandler
    {
        public override void Handle(OrderRules rule, ref ICollection<TeamInTableViewModel> teamsStats)
        {
            if (rule == OrderRules.Points)
            {
                var teamInTableViewModels = teamsStats.OrderByDescending(t => t.Points);
                teamsStats = teamInTableViewModels.ToList();
            }
            else if (Successor != null)
            {
                Successor.Handle(rule, ref teamsStats);
            }
        }
    }
}
