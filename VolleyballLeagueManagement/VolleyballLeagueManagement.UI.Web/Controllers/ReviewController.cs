using System.Collections.Generic;
using System.Web.Mvc;
using VolleyballLeagueManagement.Management.Contracts.ViewModels;
using VolleyballLeagueManagement.Management.Model;
using VolleyballLeagueManagement.Management.QueryObjects;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class ReviewController : BaseController
    {
        [HttpGet]
        public ActionResult League(int? teamId, int? leagueId)
        {
            LeaguePreviewViewModel model = null;

            using (var dbContext = new ManagementDataContext())
            {
                if (teamId.HasValue)
                    model = dbContext.Leagues.FindLeagueByTeamId((int)teamId);

                if (leagueId.HasValue)
                    model = dbContext.Leagues.FindLeagueById((int)leagueId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Regulations(int leagueId)
        {
            RegulationsViewModel model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.FindRegulationsByLeagueId(leagueId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Team(int teamId)
        {
            TeamPreviewViewModel model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Teams.FindTeamById(teamId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Leagues()
        {
            ICollection<LeaguePreviewViewModel> model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.FindAllLeagues();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Teams()
        {
            ICollection<TeamPreviewViewModel> model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Teams.FindAllTeams();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Players(int teamId)
        {
            ICollection<PlayerViewModel> model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Players.GetPlayersByTeamId(teamId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult FindTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindTeam(FindViewModel viewModel)
        {
            TeamPreviewViewModel model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Teams.FindTeamByName(viewModel.Input);
            }

            return View("Team", model);
        }

        [HttpGet]
        public ActionResult FindLeague()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindLeague(FindViewModel viewModel)
        {
            ICollection<LeaguePreviewViewModel> model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.FindLeaguesByCity(viewModel.Input);
            }

            return View("Leagues", model);
        }
    }
}