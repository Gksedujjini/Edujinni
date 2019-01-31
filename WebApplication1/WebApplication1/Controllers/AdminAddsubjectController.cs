using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminAddsubjectController : Controller
    {
        // GET: AdminAddsubject
        public ActionResult AddSubjectView()
        {
            return View();
        }
        public ActionResult AddSubjects()
        {
            return View();
        }
    }
}