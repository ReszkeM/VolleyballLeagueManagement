using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class UpdateTableOrderRulesViewModel
    {
        public int LeagueId { get; set; }

        public OrderRules FirstRule { get; set; }

        public OrderRules SecondRule { get; set; }

        public OrderRules ThirdRule { get; set; }

        public OrderRules FourthRule { get; set; }

        public OrderRules FifthRule { get; set; }
    }
}
