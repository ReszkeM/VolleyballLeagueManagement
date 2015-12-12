using System.Web.Mvc;
using VolleyballLeagueManagement.Management.Domain.Commands;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class MessagingController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNote(AddLeagueNoteCommand command)
        {
            HandleCommand(command, Json("Message added"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(SendMessageCommand command)
        {
            HandleCommand(command, Json("Message added"));

            return RedirectToAction("Index");
        }
    }
}