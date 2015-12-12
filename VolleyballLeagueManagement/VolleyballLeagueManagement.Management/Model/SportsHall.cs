namespace VolleyballLeagueManagement.Management.Model
{
    public class SportsHall
    {
        public int Id { get; set; }

        public int LeagueId { get; set; }

        public string City { get; set; }

        public string Streat { get; set; }

        public int Number { get; set; }

        public string PostCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public virtual League League { get; set; }
    }
}
