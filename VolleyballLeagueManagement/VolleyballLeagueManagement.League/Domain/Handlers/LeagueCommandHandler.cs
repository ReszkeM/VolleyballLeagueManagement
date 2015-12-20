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
        IHandler<AddGameResultCommand>,
        IHandler<UpdateGameResultCommand>,
        IHandler<UpdateGameDateCommand>,
        IHandler<GenerateCalendarCommand>
    {
        public void Handle(AddGameResultCommand command)
        {
            // TODO validate

            using (var dbContext = new LeagueDataContext())
            {
                Game game = dbContext.Games.GetGameById(command.Game.GameId);

                UpdateGameEntity(game, command.Game);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateGameResultCommand command)
        {
            // TODO validate
            using (var dbContext = new LeagueDataContext())
            {
                Game game = dbContext.Games.GetGameById(command.Game.GameId);

                UpdateGameEntity(game, command.Game);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateGameDateCommand command)
        {
            // TODO validate
            using (var dbContext = new LeagueDataContext())
            {
                Game game = dbContext.Games.GetGameById(command.GameId);
                game.Date = command.NewDate;
                dbContext.SaveChanges();
            }
        }

        public void Handle(GenerateCalendarCommand command)
        {
            using (var dbContext = new LeagueDataContext())
            {
                var calendarService = new CalendarService(command.LeagueId);
                Calendar calendar = calendarService.GenerateCompleteCalendar();

                dbContext.Calendars.Add(calendar);
                dbContext.SaveChanges();
            }
        }

        private void UpdateGameEntity(Game game, GameViewModel viewModel)
        {
            game.MVPId = viewModel.PlayerId;
            if (!game.Sets.Any())
                game.Sets = CreateGameResult(viewModel.Sets);
            else
                UpdateGameResult(game.Sets, viewModel.Sets);
        }

        private ICollection<Set> CreateGameResult(ICollection<SetViewModel> sets)
        {
            return sets.Select(s => new Set
            {
                Number = s.Number,
                Time = s.Duration,
                FirstTeamPoints = s.FirstTeamPoints,
                SecondTeamPoints = s.SecondTeamPoints
            }).ToList();
        }

        private void UpdateGameResult(ICollection<Set> sets, ICollection<SetViewModel> changedSets)
        {
            foreach (var set in sets)
            {
                var changedSet = changedSets.SingleOrDefault(s => s.SetId == set.Id);

                set.FirstTeamPoints = changedSet.FirstTeamPoints;
                set.SecondTeamPoints = changedSet.SecondTeamPoints;
                set.Time = changedSet.Duration;
            }
        }
    }
}
