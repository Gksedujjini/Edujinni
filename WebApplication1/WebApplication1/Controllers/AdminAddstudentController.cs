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
        public ActionResult StudentsOverView()
        {
            return View();
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        public ActionResult StudentInfo()
        {
            return View();
        }
    }
}