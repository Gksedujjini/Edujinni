using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminTimetableController : Controller
    {
        // GET: AdminTimetable
        public ActionResult AddTimeTable()
        {
            return View();
        }
        public ActionResult ViewTimeTable()
        {
            return View();
        }
    }
}