using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminAddstudentController : Controller
    {
        // GET: AdminAddstudent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addstudent()
        {
            return View();
        }
    }
}