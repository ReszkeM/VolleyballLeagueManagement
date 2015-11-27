using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Common.Infrastructure
{
    /// <summary>
    /// Handler for commands.
    /// </summary>
    public class CommandHandler
    {
        private string InternalError = "Wystąpił błąd wewnętrzny podczas przetwarzania operacji.";
        private readonly IBus bus;

        public CommandHandler(IBus bus)
        {
            this.bus = bus;
        }

        /// <summary>
        /// Command handler with explicit failure handler.
        /// </summary>
        public ActionResult HandleCommand<TCommand>(
                TCommand command,
                ActionResult successResult, 
                ModelStateDictionary modelState,
                HttpContextBase httpContext,
                Func<ModelStateDictionary, string, ActionResult> failureResultHandler
            ) where TCommand : ICommand
        {
            if (modelState.IsValid)
            {
                try
                {
                    bus.Send(command);
                    return successResult;
                }
                catch (ServerSideException exc)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return failureResultHandler(modelState, exc.Message);
                }
                catch (Exception exc)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return failureResultHandler(modelState, InternalError);
                }
            }

            return failureResultHandler(modelState, "");
        }
    }
}
