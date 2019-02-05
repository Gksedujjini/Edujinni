using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminAddteacherController : Controller
    {
        // GET: AdminAddteacher
        public async Task<ActionResult> TeacherView(Edujinni.Models.TeacherModels tm)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                tm.school_id = 1;
                HttpResponseMessage response = await client.PostAsJsonAsync("teachersList", tm);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    ViewBag.x = result;
                }
                // string url = "http://www.edujinni.in/";
                //     var client = new HttpClient();
                //     client.BaseAddress = new Uri(url);

            }
            return View();
        }
        public ActionResult TeacherInfo()
        {
            return View();
        }
        public ActionResult AddTeacher()
        {
            return View();
        }
        public ActionResult TeacherEditProfileView()
        {
            return View();
        }
    }
}