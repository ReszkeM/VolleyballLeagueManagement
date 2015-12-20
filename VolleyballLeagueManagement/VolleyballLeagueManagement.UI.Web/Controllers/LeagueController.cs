using System.Collections.Generic;
using System.Web.Mvc;
using VolleyballLeagueManagement.League.Contracts.ViewModels;
using VolleyballLeagueManagement.League.Domain.Commands;
using VolleyballLeagueManagement.League.Domain.Services;
using VolleyballLeagueManagement.League.Model;
using VolleyballLeagueManagement.League.QueryObjects;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class LeagueController : BaseController
    {
        [HttpGet]
        public ActionResult Calendar(int leagueId)
        {
            CalendarViewModel model;

            using (var dbContext = new LeagueDataContext())
            {
                model = dbContext.Calendars.GetCalendarByLeagueId(leagueId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult TeamCalendar(int teamId)
        {
            TeamCalendarViewModel model;

            using (var dbContext = new LeagueDataContext())
            {
                model = dbContext.Teams.GetTeamCalendarByLeagueId(teamId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Table(int leagueId)
        {
            var leagueTableService = new LeagueTableService(leagueId);
            ICollection<TeamInTableViewModel> model = leagueTableService.ExecuteTableOrderRules();

            return View(model);
        }

        [HttpGet]
        public ActionResult Game(int gameId)
        {
            GameViewModel model;

            using (var dbContext = new LeagueDataContext())
            {
                model = dbContext.Games.GetGameById(gameId).ToViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult GenerateCalendar(GenerateCalendarCommand command)
        {
            HandleCommand(command, Json("Kalendarz rozgrywek został pomyślnie wygenerowany"));


            return RedirectToAction("Index", "LeagueManagement");
        }

        [HttpGet]
        public ActionResult EditCalendar(int leagueId)
        {
            CalendarViewModel model;

            using (var dbContext = new LeagueDataContext())
            {
                model = dbContext.Calendars.GetCalendarByLeagueId(leagueId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddGameResult(int gameId)
        {
            GameViewModel model;

            using (var dbContext = new LeagueDataContext())
            {
                model = dbContext.Games.GetGameById(gameId).ToViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddGameResult(AddGameResultCommand command)
        {
            HandleCommand(command, Json("Wynik meczu został dodany"));

            return RedirectToAction("EditCalendar", new { leagueId = 1 });
        }

        [HttpPost]
        public ActionResult UpdateGameResult(UpdateGameResultCommand command)
        {
            HandleCommand(command, Json("Wynik meczu został zaktualizowany"));

            return RedirectToAction("EditCalendar", new { leagueId = 1 });
        }

        [HttpGet]
        public ActionResult UpdateGameDate(int gameId)
        {
            GameViewModel model = null;

//            using (this)
//            {
//                
//            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateGameDate(UpdateGameDateCommand command)
        {
            HandleCommand(command, Json("Termin meczu został zaktualizowany"));

            return RedirectToAction("EditCalendar", new { leagueId = 1 });
        }

        // TODO add actions for players stats
    }
}