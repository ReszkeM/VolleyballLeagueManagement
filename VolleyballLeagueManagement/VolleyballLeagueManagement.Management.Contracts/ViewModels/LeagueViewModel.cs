using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class LeagueViewModel
    {
        public int ManagerId { get; set; }

        [DisplayName("Nazwa ligi")]
        public string Name { get; set; }

        [DisplayName("Opis ligi")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Inne informacje")]
        [DataType(DataType.MultilineText)]
        public string AdditionalInformations { get; set; }

        // Address
        [DisplayName("Miasto")]
        public string City { get; set; }

        [DisplayName("Ulica")]
        public string Streat { get; set; }

        [DisplayName("Numer")]
        public int Number { get; set; }

        [DisplayName("Kod pocztowy")]
        public string PostCode { get; set; }

        [DisplayName("Aders e-mail")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        public string Phone { get; set; }

        // Regulations
        [DisplayName("Limit drużyn")]
        public int TeamsLimit { get; set; }

        [DisplayName("Limit graczy w drużynie")]
        public int PlayersLimit { get; set; }

        [DisplayName("Wpisowe")]
        public int EntryFee { get; set; }

        [DisplayName("Faza pucharowa")]
        public bool Playoffs { get; set; }

        [DisplayName("Dzień rozgrywek")]
        public Days Day { get; set; }

        [DisplayName("Data rozpoczęcia")]
        public DateTime StartTime { get; set; }

        [DisplayName("Data zakończenia")]
        public DateTime EndTime { get; set; }

        [DisplayName("Termin zapisów")]
        public DateTime ApplicationDeadline { get; set; }

        // Table order rules
        [DisplayName("Pierwsza reguła")]
        public OrderRules FirstRule { get; set; }

        [DisplayName("Druga reguła")]
        public OrderRules SecondRule { get; set; }

        [DisplayName("Trzecia Reguła")]
        public OrderRules ThirdRule { get; set; }

        [DisplayName("Czwarta reguła")]
        public OrderRules FourthRule { get; set; }

        [DisplayName("Piąta reguła")]
        public OrderRules FifthRule { get; set; }

        // Document
        public string MIMEType { get; set; }

        public int Size { get; set; }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}
