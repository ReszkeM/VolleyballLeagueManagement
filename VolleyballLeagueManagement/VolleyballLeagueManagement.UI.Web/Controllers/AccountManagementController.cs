using System.Web.Mvc;
using VolleyballLeagueManagement.Common.Extensions;
using VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels;
using VolleyballLeagueManagement.UsersAccounts.Domain.Commands;
using VolleyballLeagueManagement.UsersAccounts.Model;
using VolleyballLeagueManagement.UsersAccounts.QueryObjects;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class AccountManagementController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangeData()
        {
            ChangeUserDataViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new UserAccountDataContext())
            {
                model = dbContext.Users.GetUserData(user.UserId);
            }

            return View(model);
        }
        
        [HttpPost]
        public ActionResult ChangeData(UpdateUserDataCommand command)
        {
            HandleCommand(command, Json("User updated"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeAddress()
        {
            ChangeAddressViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new UserAccountDataContext())
            {
                model = dbContext.Users.GetUserAddress(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeAddress(UpdateUserAddressCommand command)
        {
            HandleCommand(command, Json("User address updated"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeRole()
        {
            ChangeUserRoleViewModel model;
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            using (var dbContext = new UserAccountDataContext())
            {
                model = dbContext.Users.GetUserRole(user.UserId);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeRole(ChangeUserRoleCommand command)
        {
            HandleCommand(command, Json("User role changed"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeEmail()
        {
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            var model = new ChangeEmailViewModel
            {
                UserId = user.UserId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeEmail(ChangeEmailCommand command)
        {
            HandleCommand(command, Json("User email changed"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            var model = new ChangePasswordViewModel
            {
                UserId = user.UserId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordCommand command)
        {
            HandleCommand(command, Json("User password changed"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RemoveAccount()
        {
            var user = System.Web.HttpContext.Current.GetCurrentUser();

            var model = new RemoveAccountViewModel
            {
                UserId = user.UserId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult RemoveAccount(RemoveUserCommand command)
        {
            HandleCommand(command, Json("User removed"));

            return RedirectToAction("Index");
        }
    }
}