using System;
using System.Linq;
using System.Web.Mvc;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        readonly CommandHandler commandHandler = null;

        protected BaseController()
        {
            this.commandHandler = new CommandHandler(MvcApplication.MessageBus);
        }

        protected Func<ModelStateDictionary, string, ActionResult> DefaultFailureHandler = (modelState, message) =>
        {
            return new JsonResult()
            {
                Data = new
                {
                    message = message,
                    validationErrors = modelState.Where(m => m.Value.Errors.Count > 0).Select(m => new
                    {
                        messages = m.Value.Errors.Select(e => e.ErrorMessage),
                        field = m.Key
                    })
                }
            };
        };

        protected ActionResult HandleCommand<TCommand>(TCommand command, ActionResult successResult) where TCommand : ICommand
        {
            return commandHandler.HandleCommand(command, successResult, ModelState,
                HttpContext, DefaultFailureHandler);
        }
    }
}