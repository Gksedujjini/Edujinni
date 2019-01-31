using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminAchivementController : Controller
    {
        // GET: AdminAchivement

        public ActionResult AddAchievements()
        {
            return View();
        }
        public ActionResult ViewAchievements()
        {
            return View();
        }
    }
}