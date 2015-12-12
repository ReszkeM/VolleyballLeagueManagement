using System;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class CreateLeagueCommand : ICommand
    {
        public int ManagerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AdditionalInformations { get; set; }

        // Address
        public string City { get; set; }

        public string Streat { get; set; }

        public int Number { get; set; }

        public string PostCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        // Regulations
        public int TeamsLimit { get; set; }

        public int PlayersLimit { get; set; }

        public int EntryFee { get; set; }

        public bool Playoffs { get; set; }

        public Days Days { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime ApplicationDeadline { get; set; }

        // Table order rules
        public OrderRules FirstRule { get; set; }

        public OrderRules SecondRule { get; set; }

        public OrderRules ThirdRule { get; set; }

        public OrderRules FourthRule { get; set; }

        public OrderRules FifthRule { get; set; }
    }
}
