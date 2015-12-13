using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.League.Contracts.ViewModels;

namespace VolleyballLeagueManagement.League.Domain.Handlers
{
    public class DirectMatchRuleHandler : OrderRuleHandler
    {
        public override void Handle(OrderRules rule, ref ICollection<TeamInTableViewModel> teamsStats)
        {
            if (rule == OrderRules.DirectMatch)
            {
                // TODO
            }
            else if(Successor != null)
            {
                Successor.Handle(rule, ref teamsStats);
            }
        }
    }
}
