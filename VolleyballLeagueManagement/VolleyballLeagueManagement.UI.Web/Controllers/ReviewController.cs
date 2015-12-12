using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VolleyballLeagueManagement.Management.Contracts.ViewModels;
using VolleyballLeagueManagement.Management.Model;
using VolleyballLeagueManagement.Management.QueryObjects;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class ReviewController : BaseController
    {
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
            LeaguePreviewViewModel model;

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.FindLeagueByCity(viewModel.Input);
            }

            return View("League", model);
        }
    }
}