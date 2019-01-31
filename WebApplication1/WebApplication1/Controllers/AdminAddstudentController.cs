using Edujinni.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebApplication1.Controllers
{
    public class AdminAddstudentController : Controller
    {
        // GET: AdminAddstudent
        [HttpGet]
        public async Task<ActionResult> StudentsOverView(StudentOverView details)
        {
            List<StudentOverView> StudInfo = new List<StudentOverView>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.edujinni.in/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.PostAsJsonAsync("studentsList", details);
            details.school_id = 1;
            details.class_id = 6;
            details.section_id = 3;
            //admin.insert_by = "Srikar";
            //admin.insert_date = DateTime.Now;
            //admin.update_by = "srikar";
            //admin.update_date = DateTime.Now;
            if (response.IsSuccessStatusCode == true)
            {
                //Response.Cookies.Clear();
                //ModelState.Clear();
                var StuResponse = response.Content.ReadAsStringAsync().Result;
                //StudInfo = JsonConvert.DeserializeObject<List<StudentOverView>>(StuResponse);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var d = jss.Deserialize<dynamic>(StuResponse);
                return View(d);
            }
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
        public ActionResult EditStudent()
        {
            return View();
        }
    }
}