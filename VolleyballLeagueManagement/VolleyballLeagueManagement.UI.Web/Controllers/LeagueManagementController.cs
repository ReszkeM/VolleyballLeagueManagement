using System.Web.Mvc;
using VolleyballLeagueManagement.Common.CustomAttributes;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Extensions;
using VolleyballLeagueManagement.Management.Contracts.ViewModels;
using VolleyballLeagueManagement.Management.Domain.Commands;
using VolleyballLeagueManagement.Management.Model;
using VolleyballLeagueManagement.Management.QueryObjects;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    [CustomAuthorization(Role.LeagueManager)]
    public class LeagueManagementController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            LeaguePreviewViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.FindLeagueByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = System.Web.HttpContext.Current.GetCurrentUser();
            LeagueViewModel model = LeagueExtensions.CreateNewLeague(user.UserId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateLeagueCommand command)
        {
            HandleCommand(command, Json("League created"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove()
        {
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            var model = new RemoveViewModel
            {
                Id = user.UserId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(RemoveLeagueCommand command)
        {
            HandleCommand(command, Json("League removed"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSportsHall()
        {
            UpdateSportsHallViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.GetSportsHallByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateSportsHall(UpdateSportsHallCommand command)
        {
            HandleCommand(command, Json("League address updated"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInformations()
        {
            UpdateLeagueInformationsViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.GetLeagueInformationsByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateInformations(UpdateLeagueInformationsCommand command)
        {
            HandleCommand(command, Json("League data updated"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateRegulations()
        {
            UpdateRegulationsViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.GetLeagueRegulationsByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateRegulations(UpdateRegulationsCommand command)
        {
            HandleCommand(command, Json("League regulations updated"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTableOrderRules()
        {
            UpdateTableOrderRulesViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.GetTableOrderRulesByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateTableOrderRules(UpdateTableOrderRulesCommand command)
        {
            HandleCommand(command, Json("League regulations updated"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Teams()
        {
            LeagueTeamsViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Leagues.GetLeagueTeams(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateStatus(UpdateTeamStatusCommand command)
        {
            HandleCommand(command, Json("League status changed"));

            return RedirectToAction("Index");
        }

        // TODO Generate calendar
        // TODO Change match date
        // TODO Upload document
    }
}