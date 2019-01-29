using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminAddmarksController : Controller
    {
        // GET: AdminAddmarks
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddMarks()
        {
            return View();
        }
    }
}