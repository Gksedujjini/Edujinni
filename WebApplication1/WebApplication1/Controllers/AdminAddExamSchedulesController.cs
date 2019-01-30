using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminAddExamSchedulesController : Controller
    {
        // GET: AdminAddExam           
        public ActionResult AddExamSchedules()
        {
            return View();
        }
        public ActionResult ViewExamSchedules()
        {
            return View();
        }
    }
}