using System.Linq;
using VolleyballLeagueManagement.League.Model;

namespace VolleyballLeagueManagement.League.Extensions
{
    public static class GameExtensions
    {
        public static bool HaveResult(this Game game)
        {
            int firstTeamSets = game.Sets.Count(s => s.FirstTeamPoints > s.SecondTeamPoints);
            int secondTeamSets = game.Sets.Count(s => s.FirstTeamPoints < s.SecondTeamPoints);

            return firstTeamSets != 0 || secondTeamSets != 0;
        }
    }
}
