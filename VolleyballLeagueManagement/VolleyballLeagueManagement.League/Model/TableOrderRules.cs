using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.League.Model
{
    public class TableOrderRules
    {
        public int Id { get; set; }

        public int RegulationsId { get; set; }

        public OrderRules FirstRule { get; set; }

        public OrderRules SecondRule { get; set; }

        public OrderRules ThirdRule { get; set; }

        public OrderRules FourthRule { get; set; }

        public OrderRules FifthRule { get; set; }


        public virtual Regulations Regulations { get; set; }
    }
}
