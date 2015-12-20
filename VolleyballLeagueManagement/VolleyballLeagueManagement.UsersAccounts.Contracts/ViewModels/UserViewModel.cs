using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [DisplayName("Imię")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Login { get; set; }

        [DisplayName("Hasło")]
        [CompareAttribute("PasswordRepeat", ErrorMessage = "Wprowadzone hasła nie zgadzaja się")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Password { get; set; }

        [DisplayName("Powtórz hasło")]
        [CompareAttribute("Password", ErrorMessage = "Wprowadzone hasła nie zgadzaja się")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string PasswordRepeat { get; set; }

        [DisplayName("Adres email")]
        [EmailAddress(ErrorMessage = "Adres email nie jest poprawny")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Email { get; set; }

        [DisplayName("Numer telefonu")]
        public string Phone { get; set; }

        public bool IsAccountConfirmed { get; set; }

        [DisplayName("Rola użytkownika")]
        public Role Role { get; set; }

        [DisplayName("Miasto")]
        public string City { get; set; }

        [DisplayName("Ulica")]
        public string Street { get; set; }

        [DisplayName("Numer domu")]
        public string HomeNumber { get; set; }

        [DisplayName("Numer mieszkania")]
        public string FlatNumber { get; set; }

        [DisplayName("Kod pocztowy")]
        public string PostCode { get; set; }
    }
}
