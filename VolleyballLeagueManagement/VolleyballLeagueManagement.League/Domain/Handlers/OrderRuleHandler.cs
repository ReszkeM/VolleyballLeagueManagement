using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.League.Contracts.ViewModels;

namespace VolleyballLeagueManagement.League.Domain.Handlers
{
    /// <summary>
    /// Abstract handler for CoR order rules handlers
    /// </summary>
    public abstract class OrderRuleHandler
    {
        protected OrderRuleHandler Successor;

        public void SetSuccessor(OrderRuleHandler successor)
        {
            this.Successor = successor;
        }

        public abstract void Handle(OrderRules rule, ref ICollection<TeamInTableViewModel> teamsStats);
    }
}
