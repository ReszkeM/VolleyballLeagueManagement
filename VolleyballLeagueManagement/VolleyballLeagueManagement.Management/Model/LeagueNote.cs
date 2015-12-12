namespace VolleyballLeagueManagement.Management.Model
{
    public class LeagueNote
    {
        public int Id { get; set; }

        public int LeagueId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }


        public virtual League League { get; set; }
    }
}
