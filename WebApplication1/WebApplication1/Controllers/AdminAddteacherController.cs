using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class AdminAddteacherController : Controller
    {
        // GET: AdminAddteacher
        [HttpGet]
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
                    JObject o = JObject.Parse(result);
                    JArray a = (JArray)o["Data"];
                    IList<Edujinni.Models.TeacherModels> person = a.ToObject<IList<Edujinni.Models.TeacherModels>>();
                    ViewBag.x = person;
                }
                // string url = "http://www.edujinni.in/";
                //     var client = new HttpClient();
                //     client.BaseAddress = new Uri(url);

            }
            return View("TeacherView");
        }



        //[HttpPost]
        // public ActionResult TeacherView()
        // {
        //     //http://www.edujinni.in/addingTeacher teachersList

        //     string s = null;
        //     List<Edujinni.Models.TeacherModels> li = new List<Edujinni.Models.TeacherModels>();
        //     string url = "http://www.edujinni.in/";
        //     var client = new HttpClient();
        //     client.BaseAddress = new Uri(url);
        //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //     client.DefaultRequestHeaders.Accept.Clear();
        //    // tm.school_id = 1;
        //     HttpResponseMessage response = client.GetAsync("teachersList").Result;
        //     if (response.IsSuccessStatusCode == true)
        //     {
        //         s =response.ToString();
        //     }
        //     return View();
        // }
        public ActionResult TeacherInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeacher()
        {
            return View();
        }
        public async Task<ActionResult> TeacherEditProfileView(string id, Edujinni.Models.TeacherModels tm)
        {
            Edujinni.Models.Addteacher at=new Edujinni.Models.Addteacher();
            //IList<Edujinni.Models.TeacherModels> person1;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                tm.school_id = 1;
                tm.teacher_teacherid = id;
                HttpResponseMessage response = await client.PostAsJsonAsync("teachersList", tm);
                if (response.IsSuccessStatusCode)
                {

                    var result = response.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(result);
                    JArray a = (JArray)o["Data"];
                    IList<Edujinni.Models.TeacherModels> person = a.ToObject<IList<Edujinni.Models.TeacherModels>>();
                    foreach (var item in person)
                    {
                        if (id == item.teacher_teacherid)
                        {
                            at.teacher_phone_no = item.teacher_phone_no;
                            at.teacher_id =int.Parse(item.teacher_teacherid);
                            at.teacher_fullname = item.teacher_fullname;
                            at.teacher_subject1 = item.teacher_subject1;
                            //HttpResponseMessage response1 = await client.PostAsJsonAsync("updateTeacher",item);
                            //if (response1.IsSuccessStatusCode)
                            //{

                            //    var result1 = response.Content.ReadAsStringAsync().Result;
                            //    JObject oo = JObject.Parse(result1);
                            //    JArray aa = (JArray)oo["Data"];
                            // person1 = a.ToObject<IList<Edujinni.Models.TeacherModels>>();

                        }
                    }
                }


            }
            return View(at);
        }
    }
}
