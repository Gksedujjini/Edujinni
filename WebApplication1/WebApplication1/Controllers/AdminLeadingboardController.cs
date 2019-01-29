using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminLeadingboardController : Controller
    {
        // GET: AdminLeadingboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Leadingboard()
        {
            return View();
        }
    }
}