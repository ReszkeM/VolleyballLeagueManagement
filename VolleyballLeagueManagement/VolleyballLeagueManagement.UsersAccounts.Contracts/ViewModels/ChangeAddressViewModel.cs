namespace VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels
{
    public class ChangeAddressViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HomeNumber { get; set; }

        public string FlatNumber { get; set; }

        public string PostCode { get; set; }


        public UserViewModel User { get; set; }
    }
}
