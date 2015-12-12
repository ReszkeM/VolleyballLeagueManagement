using System.Collections.Generic;
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
    [CustomAuthorization(Role.TeamManager)]
    public class TeamManagementController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            TeamPreviewViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Teams.FindTeamByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = System.Web.HttpContext.Current.GetCurrentUser();
            TeamViewModel model = TeamExtensions.CreateNewTeam(user.UserId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateTeamCommand command)
        {
            HandleCommand(command, Json("Team created"));

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
        public ActionResult Remove(RemoveTeamCommand command)
        {
            HandleCommand(command, Json("Team removed"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCoach()
        {
            UpdateCoachViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Teams.GetCoachByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCoach(UpdateCoachCommand command)
        {
            HandleCommand(command, Json("Team created"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PlayersManage()
        {
            ICollection<PlayerViewModel> model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Teams.GetPlayersByUserId(user.UserId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult MyLeague()
        {
            LeaguePreviewViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                model = dbContext.Teams.FindTeamLeague(user.UserId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult JoinLeague()
        {
            JoinLeagueViewModel model;
            ICollection<LeaguePreviewViewModel> leagues;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new ManagementDataContext())
            {
                leagues = dbContext.Leagues.FindAllLeagues();
                model = dbContext.Teams.GetTeamByUserId(user.UserId);
                model.Leagues = leagues;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult JoinLeague(JoinLeagueCommand command)
        {
            HandleCommand(command, Json("Team joined to league"));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LeaveLeague(LeaveLeagueCommand command)
        {
            HandleCommand(command, Json("Team leaved league"));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddPlayer(AddPlayerCommand command)
        {
            HandleCommand(command, Json("Player added"));

            return RedirectToAction("PlayersManage");
        }

        [HttpPost]
        public ActionResult EditPlayer(UpdatePlayerCommand command)
        {
            HandleCommand(command, Json("Player added"));

            return RedirectToAction("PlayersManage");
        }

        [HttpPost]
        public ActionResult RemovePlayer(RemovePlayerCommand command)
        {
            HandleCommand(command, Json("Player removed"));

            return RedirectToAction("PlayersManage");
        }
    }
}