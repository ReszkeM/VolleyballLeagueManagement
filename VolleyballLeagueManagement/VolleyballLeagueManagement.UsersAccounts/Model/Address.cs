namespace VolleyballLeagueManagement.UsersAccounts.Model
{
    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HomeNumber { get; set; }

        public string FlatNumber { get; set; }

        public string PostCode { get; set; }


        public virtual User User { get; set; }
    }
}
