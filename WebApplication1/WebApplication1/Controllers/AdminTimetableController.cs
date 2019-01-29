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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Timetable()
        {
            return View();
        }
    }
}