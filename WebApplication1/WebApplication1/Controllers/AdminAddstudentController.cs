using Edujinni.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.edujinni.in/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();
            details.school_id = 1;
            details.class_id = 6;
            details.section_id = 3;
            HttpResponseMessage classs = await client.PostAsJsonAsync("classNames/classDetailsList",details);
            HttpResponseMessage section = await client.PostAsJsonAsync("sectionList", details);
            HttpResponseMessage response = await client.PostAsJsonAsync("studentsList", details);
      
            if (classs.IsSuccessStatusCode == true)
            {
                var clas = classs.Content.ReadAsStringAsync().Result;
                JObject classnames = JObject.Parse(clas);
                JArray data = (JArray)classnames["Data"];
                IList<StudentOverView> classlist = data.ToObject<IList<StudentOverView>>();
                ViewBag.classnames = classlist;
            }
            if (section.IsSuccessStatusCode == true)
            {
                var clas = section.Content.ReadAsStringAsync().Result;
                JObject classnames = JObject.Parse(clas);
                JArray data = (JArray)classnames["Data"];
                IList<StudentOverView> sectionlist = data.ToObject<IList<StudentOverView>>();
                ViewBag.sections = sectionlist;
            }
            if (response.IsSuccessStatusCode == true)
            {
                var StuResponse = response.Content.ReadAsStringAsync().Result;
                JObject result = JObject.Parse(StuResponse);
                JArray data = (JArray)result["Data"];
                IList<StudentOverView> Students = data.ToObject<IList<StudentOverView>>();
                ViewBag.allstudents = Students;
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddStudent(addstudent model)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                model.school_id = 1;
                model.class_id = 6;
                model.section_id = 3;
                HttpResponseMessage response = await client.PostAsJsonAsync("addingStudentDetails ", model);
                HttpResponseMessage classes = await client.PostAsJsonAsync("classNames/classDetailsList", model);
                HttpResponseMessage sections = await client.PostAsJsonAsync("sectionList", model);
                if(classes.IsSuccessStatusCode==true)
                {
                    var classnames = classes.Content.ReadAsStringAsync().Result;
                    JObject cl = JObject.Parse(classnames);
                    JArray cll = (JArray)cl["Data"];
                    IList<addstudent> classdetails = cll.ToObject<IList<addstudent>>();
                    ViewBag.clsname = classdetails;
                }
                if(sections.IsSuccessStatusCode==true)
                {
                    var section = sections.Content.ReadAsStringAsync().Result;
                    JObject s = JObject.Parse(section);
                    JArray ss = (JArray)s["Data"];
                    IList<addstudent> sectionnames = ss.ToObject<IList<addstudent>>();
                    ViewBag.sectnname = sectionnames;
                }
                if (response.IsSuccessStatusCode==true)
                {
                    Response.Write("<script>alert('Student Added successfully')</script>");
                    return RedirectToAction("StudentsOverView");
                }
                Response.Write("<script>Error adding the Event</script>");
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
        
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> AddStudent(StudentOverView model)
        {
            using (HttpClient client = new HttpClient())
            {
                List<Edujinni.Models.addstudent> list = new List<Edujinni.Models.addstudent>();
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                model.school_id = 1;
                HttpResponseMessage classes = await client.PostAsJsonAsync("classNames/classDetailsList", model);
                HttpResponseMessage sections = await client.PostAsJsonAsync("sectionList", model);
                if (classes.IsSuccessStatusCode == true)
                {
                    var classnames = classes.Content.ReadAsStringAsync().Result;
                    JObject cl = JObject.Parse(classnames);
                    JArray cll = (JArray)cl["Data"];
                    IList<addstudent> classdetails = cll.ToObject<IList<addstudent>>();
                    IEnumerable<SelectListItem> cls = cll.ToObject<IEnumerable<SelectListItem>>();
                    ViewBag.clsname = classdetails;
                    SelectList listt = new SelectList(cls, "class_name");
                    ViewBag.clsnamee = listt;
                }
                if (sections.IsSuccessStatusCode == true)
                {
                    var section = sections.Content.ReadAsStringAsync().Result;
                    JObject s = JObject.Parse(section);
                    JArray ss = (JArray)s["Data"];
                    IList<addstudent> sectionnames = ss.ToObject<IList<addstudent>>();
                    ViewBag.sectnname = sectionnames;
                }
            }
            return View();
        }
        public ActionResult StudentInfo()
        {
            return View();
        }
    }
}