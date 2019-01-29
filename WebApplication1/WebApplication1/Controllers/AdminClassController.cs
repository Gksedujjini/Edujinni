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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addclass()
        {
            return View();
        }
    }
}