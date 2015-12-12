using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateTableOrderRulesCommand : ICommand
    {
        public int LeagueId { get; set; }

        public OrderRules FirstRule { get; set; }

        public OrderRules SecondRule { get; set; }

        public OrderRules ThirdRule { get; set; }

        public OrderRules FourthRule { get; set; }

        public OrderRules FifthRule { get; set; }
    }
}
