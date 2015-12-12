namespace VolleyballLeagueManagement.Management.Contracts.ViewModels
{
    public class TeamViewModel
    {
        public int ManagerId { get; set; }

        public string Name { get; set; }

        // Coach
        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public int CoachAge { get; set; }

        public string CoachPhone { get; set; }

        public string CoachEmail { get; set; }
    }
}
