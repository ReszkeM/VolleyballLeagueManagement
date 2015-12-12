namespace VolleyballLeagueManagement.Management.Model
{
    public class Coach
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public virtual Team Team { get; set; }
    }
}
