using System;
using System.Linq;
using VolleyballLeagueManagement.Management.Contracts.ViewModels;
using VolleyballLeagueManagement.Management.Model;

namespace VolleyballLeagueManagement.Management.QueryObjects
{
    public static class TeamExtensions
    {
        public static TeamPreviewViewModel FindTeamByUserId(this IQueryable<Team> teams, int userId)
        {
            var team = teams.FirstOrDefault(u => u.ManagerId == userId);

            if (team == null)
                return new TeamPreviewViewModel();

            return team.ToViewModel();
        }

        public static UpdateCoachViewModel GetCoachByUserId(this IQueryable<Team> teams, int userId)
        {
            var team = teams.FirstOrDefault(u => u.ManagerId == userId);

            if (team == null || team.Coach == null)
                throw new ArgumentException(
                    string.Format("Team with user id: {0} does not exist in the database.", userId));

            return GetCoach(team);
        }

       
        public static TeamViewModel CreateNewTeam(int userId)
        {
            return new TeamViewModel
            {
                ManagerId = userId
            };
        }


        private static TeamPreviewViewModel ToViewModel(this Team team)
        {
            return new TeamPreviewViewModel
            {
                Name = team.Name,
                Status = team.Status,
                CoachFirstName = team.Coach.FirstName,
                CoachLastName = team.Coach.LastName
            };
        }

        private static UpdateCoachViewModel GetCoach(Team team)
        {
            return new UpdateCoachViewModel
            {
                TeamId = team.Id,
                CoachFirstName = team.Coach.FirstName,
                CoachLastName = team.Coach.LastName,
                CoachAge = team.Coach.Age,
                CoachEmail = team.Coach.Email,
                CoachPhone = team.Coach.Phone,
            };
        }
    }
}
