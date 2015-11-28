using System.Web.Mvc;
using VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels;
using VolleyballLeagueManagement.UsersAccounts.Domain.Commands;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Register()
        {
            var model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(AddUserCommand command)
        {
            HandleCommand(command, Json("User added"));

            return RedirectToAction("About", "Home");
        }
    }
}