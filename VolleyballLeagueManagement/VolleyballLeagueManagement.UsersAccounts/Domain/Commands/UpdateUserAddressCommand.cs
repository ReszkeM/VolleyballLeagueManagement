using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class UpdateUserAddressCommand : ICommand
    {
        public int UserId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HomeNumber { get; set; }

        public string FlatNumber { get; set; }

        public string PostCode { get; set; }
    }
}
