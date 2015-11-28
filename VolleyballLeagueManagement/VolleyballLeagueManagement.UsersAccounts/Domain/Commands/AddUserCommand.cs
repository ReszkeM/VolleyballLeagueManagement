using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class AddUserCommand : ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string PasswordRepeat { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int RoleValue { get; set; }


        public string City { get; set; }

        public string Street { get; set; }

        public string HomeNumber { get; set; }

        public string FlatNumber { get; set; }

        public string PostCode { get; set; }
    }
}
