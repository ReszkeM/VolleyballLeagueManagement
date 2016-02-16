using System;
using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.Common.Interfaces;
using VolleyballLeagueManagement.League.Contracts.ViewModels;
using VolleyballLeagueManagement.League.Domain.Commands;
using VolleyballLeagueManagement.League.Domain.Services;
using VolleyballLeagueManagement.League.Model;
using VolleyballLeagueManagement.League.QueryObjects;

namespace VolleyballLeagueManagement.League.Domain.Handlers
{
    public class LeagueCommandHandler :
        IHandler<UpdateGameResultCommand>,
        IHandler<UpdateGameDateCommand>,
        IHandler<GenerateCalendarCommand>
    {
        public void Handle(UpdateGameResultCommand command)
        {
            // TODO validate
            using (var dbContext = new LeagueDataContext())
            {
                Game game = dbContext.Games.GetGameById(command.GameId);

                UpdateGameEntity(game, command.Sets);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateGameDateCommand command)
        {
            // TODO validate
            using (var dbContext = new LeagueDataContext())
            {
                Game game = dbContext.Games.GetGameById(command.GameId);
                command.Date = command.Date.AddHours(command.Time.Hours);
                command.Date = command.Date.AddMinutes(command.Time.Minutes);
                game.Date = command.Date;
                dbContext.SaveChanges();
            }
        }

        public void Handle(GenerateCalendarCommand command)
        {
            using (var dbContext = new LeagueDataContext())
            {
                Model.League league = dbContext.Leagues.GetLeagueById(command.LeagueId);

                var calendarService = new CalendarService(command.LeagueId);
                Calendar calendar = calendarService.GenerateCompleteCalendar();

                calendar.League = league;
                calendar.LeagueId = league.Id;
                league.Calendar = calendar;
                
                dbContext.Calendars.Add(calendar);
                dbContext.SaveChanges();
            }
        }

        private void UpdateGameEntity(Game game, ICollection<SetViewModel> viewModel)
        {
            //game.MVPId = viewModel.PlayerId;
            if (!game.Sets.Any())
                game.Sets = CreateGameResult(viewModel);
            else
                UpdateGameResult(game.Sets, viewModel);
        }

        private ICollection<Set> CreateGameResult(ICollection<SetViewModel> sets)
        {
            return sets.Select(s => new Set
            {
                Number = s.Number,
                Time = new TimeSpan(s.DurationInMinutes),
                FirstTeamPoints = s.FirstTeamPoints,
                SecondTeamPoints = s.SecondTeamPoints
            }).ToList();
        }

        private void UpdateGameResult(ICollection<Set> sets, ICollection<SetViewModel> changedSets)
        {
            foreach (var set in sets)
            {
                var changedSet = changedSets.SingleOrDefault(s => s.Number == set.Number);

                set.FirstTeamPoints = changedSet.FirstTeamPoints;
                set.SecondTeamPoints = changedSet.SecondTeamPoints;
                set.Time = new TimeSpan(changedSet.DurationInMinutes);
            }
        }
    }
}
