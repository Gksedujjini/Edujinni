using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminAddEventsController : Controller
    {
        // GET: AdminAddEvents
        public ActionResult ViewEvents()
        {
            return View();
        }
        public ActionResult AddEvents()
        {
            return View();
        }
    }
}