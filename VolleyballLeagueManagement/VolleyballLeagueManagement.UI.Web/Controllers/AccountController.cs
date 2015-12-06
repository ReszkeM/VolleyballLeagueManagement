using System;
using System.Web.Mvc;
using VolleyballLeagueManagement.UsersAccounts.Domain.Commands;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AddUserCommand command)
        {
            HandleCommand(command, Json("User added"));

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogInCommand command)
        {
            HandleCommand(command, Json("LoggIn"));

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            var command = new LogOffCommand();

            HandleCommand(command, Json("LogOff"));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordCommand command)
        {
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult ConfirmAccount(Guid confirmGuid)
        {
            var command = new ConfirmAccountCommand
            {
                ConfirmGuid = confirmGuid
            };

            HandleCommand(command, Json("User confirmed"));

            return View();
        }
    }
}