namespace VolleyballLeagueManagement.League.Contracts.ViewModels
{
    public class TeamInTableViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public int Games { get; set; }

        public int WinGames { get; set; }

        public int WinToZero { get; set; }

        public int WinToOne { get; set; }

        public int WinToTwo { get; set; }

        public int LoseGames { get; set; }

        public int LoseToZero { get; set; }

        public int LoseToOne { get; set; }

        public int LoseToTwo { get; set; }

        public int WinSets { get; set; }

        public int LoseSets { get; set; }

        public double SetsRatio { get; set; }

        public int WinPoints { get; set; }

        public int LosePoints { get; set; }

        public double PointsRatio { get; set; }
    }
}
