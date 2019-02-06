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

            Edujinni.Models.Addteacher at = new Edujinni.Models.Addteacher();

            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://www.edujinni.in/");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    tm.school_id = 1;
            //    HttpResponseMessage response0 = await client.PostAsJsonAsync("classDetailsList", tm);
            //    if(response0.IsSuccessStatusCode)
            //    {
            //        var result = response0.Content.ReadAsStringAsync().Result;
            //        JObject o = JObject.Parse(result);
            //        JArray a = (JArray)o["Data"];
            //        IList<Edujinni.Models.TeacherModels> person = a.ToObject<IList<Edujinni.Models.TeacherModels>>();
            //        ViewBag.s = person;
            //    }


            //IList<Edujinni.Models.TeacherModels> person1;
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
                    foreach (var item in person)
                    {
                        if (id == item.teacher_teacherid)
                        {
                            tm.teacher_teacherid = id;
                            HttpResponseMessage response1 = await client.PostAsJsonAsync("particular/Teacher", tm);
                            if (response1.IsSuccessStatusCode)
                            {
                                var result1 = response1.Content.ReadAsStringAsync().Result;
                                JObject oo = JObject.Parse(result1);
                                JArray aa = (JArray)oo["Data"];
                                IList<Edujinni.Models.TeacherModels> person1 = aa.ToObject<IList<Edujinni.Models.TeacherModels>>();
                                foreach (var item1 in person1)
                                {
                                    if (id == item1.teacher_teacherid)
                                    {
                                        at.teacher_first_name = item1.teacher_first_name;
                                        at.teacher_last_name = item1.teacher_last_name;
                                        at.teacher_gender = item1.teacher_gender;
                                        at.teacher_email = item1.teacher_email;
                                        at.teacher_phone_no = item1.teacher_phone_no;
                                        at.teacher_dob = item1.teacher_dob;
                                        at.teacher_subject1 = item1.teacher_subject1;
                                        at.teacher_subject2 = item1.teacher_subject2;
                                        at.teacher_qualification = item1.teacher_qualification;
                                        at.teacher_id = item1.teacher_id;
                                        at.teacher_flat_no = item1.teacher_flat_no;
                                        at.teacher_street = item1.teacher_street;
                                        at.teacher_date_of_joining = item1.teacher_date_of_joining;
                                        at.teacher_area = item1.teacher_area;
                                        at.teacher_city = item1.teacher_city;
                                        at.teacher_state = item1.teacher_state;
                                        at.teacher_pincode = item1.teacher_pincode;
                                    }
                                }

                                //    at.teacher_phone_no = item.teacher_phone_no;
                                //at.teacher_teacherid = item.teacher_teacherid;
                                //at.teacher_fullname = item.teacher_fullname;
                                //at.teacher_subject1 = item.teacher_subject1;
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
}
