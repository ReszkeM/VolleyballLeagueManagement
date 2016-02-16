using System.ComponentModel;

namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class TeamViewModel
    {
        public int ManagerId { get; set; }

        [DisplayName("Nazwa")]
        public string Name { get; set; }

        // Coach
        [DisplayName("Imię trenera")]
        public string CoachFirstName { get; set; }

        [DisplayName("Nazwisko trenera")]
        public string CoachLastName { get; set; }

        [DisplayName("Wiek trenera")]
        public int CoachAge { get; set; }

        [DisplayName("Telefon kontaktowy")]
        public string CoachPhone { get; set; }

        [DisplayName("Adres e-mail")]
        public string CoachEmail { get; set; }
    }
}
