using System.Web.Mvc;
using VolleyballLeagueManagement.UsersAccounts.Domain.Commands;

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
            return View();
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
            return View();
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
            return View();
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
            return View();
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
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordCommand command)
        {
            HandleCommand(command, Json("User password changed"));

            return RedirectToAction("Index");
        }
    }
}