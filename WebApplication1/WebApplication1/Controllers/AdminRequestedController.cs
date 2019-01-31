using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminRequestedController : Controller
    {
        // GET: AdminRequested
        public ActionResult RequestedPage()
        {
            return View();
        }
    }
}