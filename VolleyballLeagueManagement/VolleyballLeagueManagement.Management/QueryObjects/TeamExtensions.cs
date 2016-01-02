using System;
using System.Collections.Generic;
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

        public static TeamPreviewViewModel FindTeamById(this IQueryable<Team> teams, int teamId)
        {
            var team = teams.FirstOrDefault(u => u.Id == teamId);

            if (team == null)
                return new TeamPreviewViewModel();

            return team.ToViewModel();
        }

        public static TeamPreviewViewModel FindTeamByName(this IQueryable<Team> teams, string name)
        {
            var team = teams.FirstOrDefault(u => u.Name == name);

            if (team == null)
                return new TeamPreviewViewModel();

            return team.ToViewModel();
        }

        public static JoinLeagueViewModel GetTeamByUserId(this IQueryable<Team> teams, int userId)
        {
            var team = teams.FirstOrDefault(u => u.ManagerId == userId);

            if (team == null || team.Coach == null)
                throw new ArgumentException(
                    string.Format("Team with user id: {0} does not exist in the database.", userId));

            return GetTeam(team);
        }

        public static UpdateCoachViewModel GetCoachByUserId(this IQueryable<Team> teams, int userId)
        {
            var team = teams.FirstOrDefault(u => u.ManagerId == userId);

            if (team == null || team.Coach == null)
                throw new ArgumentException(
                    string.Format("Team with user id: {0} does not exist in the database.", userId));

            return GetCoach(team);
        }

        public static ICollection<TeamPreviewViewModel> FindAllTeams(this IQueryable<Team> teams)
        {
            return teams.Select(t => new TeamPreviewViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Status = t.Status,
                CoachFirstName = t.Coach.FirstName,
                CoachLastName = t.Coach.LastName
            }).ToList();
        }

        public static ICollection<PlayerViewModel> GetPlayersByUserId(this IQueryable<Team> teams, int userId)
        {
            var team = teams.FirstOrDefault(u => u.ManagerId == userId);

            if (team == null || team.Players == null)
                throw new ArgumentException(
                    string.Format("Team with user id: {0} does not exist in the database.", userId));

            return team.Players.ToViewModel();
        }

        public static ICollection<PlayerViewModel> GetPlayersByTeamId(this IQueryable<Player> players, int teamId)
        {
            var teamPlayers = players.Where(p => p.TeamId == teamId).ToList();

            return teamPlayers.ToViewModel();
        }

        public static ICollection<TeamPreviewViewModel> ToViewModel(this ICollection<Team> teams)
        {
            return teams.Select(t => new TeamPreviewViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Status = t.Status,
                CoachFirstName = t.Coach.FirstName,
                CoachLastName = t.Coach.LastName
            }).ToList();
        }

       
        public static TeamViewModel CreateNewTeam(int userId)
        {
            return new TeamViewModel
            {
                ManagerId = userId
            };
        }


        public static TeamPreviewViewModel ToViewModel(this Team team)
        {
            return new TeamPreviewViewModel
            {
                Name = team.Name,
                Status = team.Status,
                CoachFirstName = team.Coach.FirstName,
                CoachLastName = team.Coach.LastName
            };
        }

        private static JoinLeagueViewModel GetTeam(Team team)
        {
            return new JoinLeagueViewModel
            {
                TeamId = team.Id,
                Leagues = new List<LeaguePreviewViewModel>()
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

        private static List<PlayerViewModel> ToViewModel(this ICollection<Player> players)
        {
            return players.Select(p => new PlayerViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Growth = p.Growth,
                Position = p.Position,
                IsCapitan = p.IsCapitan
            }).ToList();
        }
    }
}
