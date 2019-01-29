using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminClassController : Controller
    {
        // GET: AdminClass
    
        public ActionResult AddClass()
        {
            return View();
        }
        public ActionResult ViewClass()
        {
            return View();
        }
     
    }
}