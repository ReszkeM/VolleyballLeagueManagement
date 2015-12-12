﻿using System;
using System.Linq;
using VolleyballLeagueManagement.Management.Contracts.ViewModels;
using VolleyballLeagueManagement.Management.Model;

namespace VolleyballLeagueManagement.Management.QueryObjects
{
    public static class LeagueExtensions
    {
        public static LeaguePreviewViewModel FindLeagueByUserId(this IQueryable<League> leagues, int userId)
        {
            var league = leagues.FirstOrDefault(u => u.OrganizerId == userId);

            if (league == null)
                return new LeaguePreviewViewModel();

            return league.ToViewModel();
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
                Playoffs = league.Regulations.Playoffs
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

        private static LeaguePreviewViewModel ToViewModel(this League league)
        {
            return new LeaguePreviewViewModel
            {
                Name = league.Name,
                City = league.SportsHall.City,
                Status = league.Status,
                ApplicationDeadline = league.Regulations.ApplicationDeadline,
                StartTime = league.Regulations.StartTime,
                ApprovedTeams = league.Teams.Count,
                TeamsLimit = league.Regulations.TeamsLimit
            };
        }
    }
}
