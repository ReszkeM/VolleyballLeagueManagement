﻿using System;
using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Management.Contracts.ViewModels;
using VolleyballLeagueManagement.Management.Model;

namespace VolleyballLeagueManagement.Management.QueryObjects
{
    public static class LeagueExtensions
    {
        public static ICollection<LeaguePreviewViewModel> FindAllLeagues(this IQueryable<League> leagues)
        {
            var league = leagues.ToViewModel();

            if (league.Count == 0)
                return new List<LeaguePreviewViewModel>();

            return league;
        }

        public static LeaguePreviewViewModel FindLeagueByUserId(this IQueryable<League> leagues, int userId)
        {
            var league = leagues.FirstOrDefault(u => u.OrganizerId == userId);

            if (league == null)
                return null;

            return league.ToViewModel();
        }

        public static LeaguePreviewViewModel FindLeagueById(this IQueryable<League> leagues, int leagueId)
        {
            var league = leagues.FirstOrDefault(u => u.Id == leagueId);

            if (league == null)
                return null;

            return league.ToViewModel();
        }

        public static LeaguePreviewViewModel FindLeagueByTeamId(this IQueryable<League> leagues, int teamId)
        {
            var league = leagues.FirstOrDefault(l => l.Teams.Any(t => t.Id == teamId));

            if (league == null)
                return null;

            return league.ToViewModel();
        }

        public static ICollection<LeaguePreviewViewModel> FindLeaguesByCity(this IQueryable<League> leagues, string city)
        {
            var league = leagues.Where(u => u.SportsHall.City == city);

            return league.ToViewModel();
        }

        public static LeaguePreviewViewModel FindTeamLeague(this IQueryable<Team> teams, int userId)
        {
            var team = teams.FirstOrDefault(u => u.ManagerId == userId);

            if (team == null || team.League == null)
                return null;

            return team.League.ToViewModel();
        }

        public static RegulationsViewModel FindRegulationsByLeagueId(this IQueryable<League> leagues, int leagueId)
        {
            var league = leagues.FirstOrDefault(l => l.Id == leagueId);

            return league.GetRegulations();
        }

        public static UpdateSportsHallViewModel GetSportsHallByUserId(this IQueryable<League> leagues, int userId)
        {
            League league = FindLeague(leagues, userId);
            return GetSportsHall(league);
        }

        public static UpdateLeagueInformationsViewModel GetLeagueInformationsByUserId(this IQueryable<League> leagues, int userId)
        {
            League league = FindLeague(leagues, userId);
            return GetLeagueInformations(league);
        }

        public static UpdateRegulationsViewModel GetLeagueRegulationsByUserId(this IQueryable<League> leagues, int userId)
        {
            League league = FindLeague(leagues, userId);
            return GetLeagueRegulations(league);
        }

        public static UpdateTableOrderRulesViewModel GetTableOrderRulesByUserId(this IQueryable<League> leagues, int userId)
        {
            League league = FindLeague(leagues, userId);
            return GetTableOrderRules(league.Regulations.TableOrderRules, league.Id);
        }

        public static UpdateLeagueStatusViewModel GetLeagueStatusByUserId(this IQueryable<League> leagues, int userId)
        {
            League league = FindLeague(leagues, userId);
            return GetLeagueStatus(league);
        }

        public static LeagueTeamsViewModel GetLeagueTeams(this IQueryable<League> leagues, int userId)
        {
            League league = FindLeague(leagues, userId);
            return GetLeagueTeams(league);
        }

        public static LeagueViewModel CreateNewLeague(int userId)
        {
            return new LeagueViewModel
            {
                ManagerId = userId,
                ApplicationDeadline = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };
        }

        public static LeaguePreviewViewModel ToViewModel(this League league)
        {
            return new LeaguePreviewViewModel
            {
                LeagueId = league.Id,
                Name = league.Name,
                City = league.SportsHall.City,
                Status = league.Status,
                ApplicationDeadline = league.Regulations.ApplicationDeadline,
                StartTime = league.Regulations.StartTime,
                ApprovedTeams = league.Teams.Count,
                TeamsLimit = league.Regulations.TeamsLimit,
                Day = league.Regulations.Day
            };
        }



        private static League FindLeague(IQueryable<League> leagues, int userId)
        {
            var league = leagues.FirstOrDefault(u => u.OrganizerId == userId);

            if (league == null)
                throw new ArgumentException(
                    string.Format("League with user id: {0} does not exist in the database.", userId));

            return league;
        }

        private static UpdateSportsHallViewModel GetSportsHall(League league)
        {
            return new UpdateSportsHallViewModel
            {
                LeagueId = league.Id,
                City = league.SportsHall.City,
                Streat = league.SportsHall.Streat,
                Number = league.SportsHall.Number,
                PostCode = league.SportsHall.PostCode,
                Email = league.SportsHall.Email,
                Phone = league.SportsHall.Phone,
            };
        }

        private static UpdateLeagueInformationsViewModel GetLeagueInformations(League league)
        {
            return new UpdateLeagueInformationsViewModel
            {
                LeagueId = league.Id,
                Name = league.Name,
                Description = league.Description,
                AdditionalInformations = league.AdditionalInformations
            };
        }

        private static UpdateRegulationsViewModel GetLeagueRegulations(League league)
        {
            return new UpdateRegulationsViewModel
            {
                LeagueId = league.Id,
                TeamsLimit = league.Regulations.TeamsLimit,
                PlayersLimit = league.Regulations.PlayersLimit,
                ApplicationDeadline = league.Regulations.ApplicationDeadline,
                StartTime = league.Regulations.StartTime,
                EndTime = league.Regulations.EndTime,
                EntryFee = league.Regulations.EntryFee,
                Playoffs = league.Regulations.Playoffs,
                Day = league.Regulations.Day
            };
        }

        private static UpdateTableOrderRulesViewModel GetTableOrderRules(TableOrderRules rules, int leagueId)
        {
            return new UpdateTableOrderRulesViewModel
            {
                LeagueId = leagueId,
                FirstRule = rules.FirstRule,
                SecondRule = rules.SecondRule,
                ThirdRule = rules.ThirdRule,
                FourthRule = rules.FourthRule,
                FifthRule = rules.FifthRule,
            };
        }

        private static UpdateLeagueStatusViewModel GetLeagueStatus(League league)
        {
            return  new UpdateLeagueStatusViewModel
            {
                LeagueId = league.Id,
                Status = (int) league.Status
            };
        }

        private static LeagueTeamsViewModel GetLeagueTeams(League league)
        {
            return new LeagueTeamsViewModel
            {
                LeagueId = league.Id,
                Teams = league.Teams.ToViewModel(),
                TeamsToApprove = league.TeamsWaitingForApprove.ToViewModel()
            };
        }

        private static ICollection<LeaguePreviewViewModel> ToViewModel(this IQueryable<League> leagues)
        {
            return leagues.Select(league => new LeaguePreviewViewModel
            {
                LeagueId = league.Id,
                Name = league.Name,
                City = league.SportsHall.City,
                Status = league.Status,
                ApplicationDeadline = league.Regulations.ApplicationDeadline,
                StartTime = league.Regulations.StartTime,
                ApprovedTeams = league.Teams.Count,
                TeamsLimit = league.Regulations.TeamsLimit,
                Day = league.Regulations.Day
            }).ToList();
        }

        private static RegulationsViewModel GetRegulations(this League league)
        {
            return new RegulationsViewModel
            {
                Id = league.Regulations.Id,
                LeagueId = league.Id,
                LeagueName = league.Name,
                ApplicationDeadline = league.Regulations.ApplicationDeadline,
                StartTime = league.Regulations.StartTime,
                EndTime = league.Regulations.EndTime,
                Day = league.Regulations.Day,
                DocumentId = league.Regulations.DocumentId,
                EntryFee = league.Regulations.EntryFee,
                Playoffs = league.Regulations.Playoffs,
                PlayersLimit = league.Regulations.PlayersLimit,
                TeamsLimit = league.Regulations.TeamsLimit,
                TableOrderRules = new List<OrderRules>
                {
                    league.Regulations.TableOrderRules.FirstRule,
                    league.Regulations.TableOrderRules.SecondRule,
                    league.Regulations.TableOrderRules.ThirdRule,
                    league.Regulations.TableOrderRules.FourthRule,
                    league.Regulations.TableOrderRules.FifthRule
                }
            };
        }
    }
}
