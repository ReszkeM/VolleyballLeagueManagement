﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace VolleyballLeagueManagement.UI.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}