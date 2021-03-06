﻿using System;
using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.League.Contracts.ViewModels;
using VolleyballLeagueManagement.League.Model;

namespace VolleyballLeagueManagement.League.QueryObjects
{
    public static class LeagueExtensions
    {
        public static Game GetGameById(this IQueryable<Game> games, int gameId)
        {
            Game game = games.SingleOrDefault(g => g.Id == gameId);
            return game;
        }

        public static Model.League GetLeagueById(this IQueryable<Model.League> leagues, int leagueId)
        {
            Model.League league = leagues.SingleOrDefault(l => l.Id == leagueId);
            return league;
        }

        public static CalendarViewModel GetCalendarByLeagueId(this IQueryable<Calendar> calendars, int leagueId)
        {
            var calender = calendars.SingleOrDefault(c => c.LeagueId == leagueId);
            var calendarViewModel = calender.ToViewModel();

            return calendarViewModel;
        }

        public static TeamCalendarViewModel GetTeamCalendarByLeagueId(this IQueryable<Team> teams, int teamId)
        {
            Team team = teams.SingleOrDefault(t => t.Id == teamId);

            return team.ToViewModel();
        }

        public static string GetGameResult(this ICollection<SetViewModel> sets)
        {
            int firstTeamSets = 0;
            int secondTeamSets = 0;

            foreach (var set in sets)
            {
                var i = set.FirstTeamPoints > set.SecondTeamPoints ? firstTeamSets++ : secondTeamSets++;
            }

            return String.Format("{0}:{1}", firstTeamSets, secondTeamSets);
        }

        public static GameViewModel ToViewModel(this Game game)
        {
            return new GameViewModel
            {
                GameId = game.Id,
                FirstTeamId = game.FirstTeamId,
                FirstTeamName = game.FirstTeam.Name,
                SecondTeamId = game.SecondTeamId,
                SecondTeamName = game.SecondTeam.Name,
                Date = game.Date,
                PlayerId = game.MVPId ?? 0,
                PlayerName = game.MVP != null ? String.Format("{0} {1}", game.MVP.FirstName, game.MVP.LastName) : String.Empty,
                Sets = game.Sets.Select(s => new SetViewModel
                {
                    SetId = s.Id,
                    Number = s.Number,
                    Duration = s.Time,
                    FirstTeamPoints = s.FirstTeamPoints,
                    SecondTeamPoints = s.SecondTeamPoints
                }).ToList()
            };
        }

        private static CalendarViewModel ToViewModel(this Calendar calendar)
        {
            return new CalendarViewModel
            {
                CalendarId = calendar.Id,
                Rounds = calendar.Rounds.Select(r => new RoundViewModel
                {
                    RoundId = r.Id,
                    Date = r.Date,
                    Number = r.Number,
                    Games = r.Games.Select(g => g.ToViewModel()).ToList()
                }).ToList()
            };
        }

        private static TeamCalendarViewModel ToViewModel(this Team team)
        {
            return new TeamCalendarViewModel
            {
                TeamId = team.Id,
                TeamName = team.Name,
                Games = team.GetGames()
            };
        }

        private static ICollection<GameViewModel> GetGames(this Team team)
        {
            var model = new List<GameViewModel>();
            ICollection<Round> rounds = team.League.Calendar.Rounds;

            foreach (var round in rounds)
            {
                model.AddRange(round.Games
                        .Where(g => g.FirstTeamId == team.Id || g.SecondTeamId == team.Id)
                        .Select(g => g.ToViewModel())
                        .ToList()
                    );
            }
            return model;
        }
    }
}
