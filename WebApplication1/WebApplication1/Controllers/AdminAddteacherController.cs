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
            }
            return View("TeacherView");
        }
        [HttpGet]
        public ActionResult TeacherInfo()
        {
            return View();
        }
        //[HttpGet]

        //public async Task<ActionResult> AddTeacher(Edujinni.Models.Addteacher at)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://www.edujinni.in");
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Clear();
        //        at.school_id = 1;
        //        HttpResponseMessage response = await client.PostAsJsonAsync("addingTeacher", at);
        //        if (response.IsSuccessStatusCode)
        //        {

        //        }
        //    }

        //    return View();
        //}
        
        public async Task<ActionResult> TeacherEditProfileView(string id, Edujinni.Models.TeacherModels tm, string b1)
        {
           
            List<SelectListItem> li = new List<SelectListItem>(); List<SelectListItem> list = new List<SelectListItem>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                tm.school_id = 1;
                tm.section_id = 3;
                tm.class_id = 5;
                HttpResponseMessage response = await client.PostAsJsonAsync("subjectsList", tm);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(result);
                    JArray a = (JArray)o["Data"];
                    IList<Edujinni.Models.TeacherModels> person = a.ToObject<IList<Edujinni.Models.TeacherModels>>();
                    List<Edujinni.Models.TeacherModels> p = (List<Edujinni.Models.TeacherModels>)person;
                    foreach (var item in p)
                    {
                        li.Add(new SelectListItem() { Text = item.subject_name, Value = item.subject_id.ToString() });
                    }
                    TempData["x"] = li;
                    TempData.Keep();
                }

                //return View();
                Edujinni.Models.Addteacher at = new Edujinni.Models.Addteacher();
                //using (HttpClient client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("http://www.edujinni.in/");
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    tm.school_id = 1;
                HttpResponseMessage response1 = await client.PostAsJsonAsync("teachersList", tm);
                if (response1.IsSuccessStatusCode)
                {
                    var result = response1.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(result);
                    JArray a = (JArray)o["Data"];
                    IList<Edujinni.Models.TeacherModels> person = a.ToObject<IList<Edujinni.Models.TeacherModels>>();
                    foreach (var item in person)
                    {
                        if (id == item.teacher_id.ToString())
                        {
                            tm.teacher_id = int.Parse(id);
                            HttpResponseMessage response2 = await client.PostAsJsonAsync("particular/Teacher", tm);
                            if (response2.IsSuccessStatusCode)
                            {
                                var result1 = response2.Content.ReadAsStringAsync().Result;
                                JObject oo = JObject.Parse(result1);
                                JArray aa = (JArray)oo["Data"];
                                IList<Edujinni.Models.TeacherModels> person1 = aa.ToObject<IList<Edujinni.Models.TeacherModels>>();
                                foreach (var item1 in person1)
                                {
                                    if (id == item1.teacher_id.ToString())
                                    {
                                        at.teacher_first_name = item1.teacher_first_name;
                                        at.teacher_last_name = item1.teacher_last_name;
                                        at.teacher_gender = item1.teacher_gender;
                                        at.teacher_email = item1.teacher_email;
                                        at.teacher_phone_no = item1.teacher_phone_no.ToString();
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
                                        at.teacher_department = item1.teacher_department;
                                    }
                                }
                            }
                        }
                    }
                }
                return View(at);
            }
        }
        [HttpPost]
        public async Task<ActionResult> TeacherEditProfileView(Edujinni.Models.TeacherModels tm, string b1,string id)
        {

            switch (b1)
            {
                //case "cancel":
                //    return RedirectToAction("TeacherView", "AdminAddteacher");
                //    break;

                case "Update":
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://www.edujinni.in/");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Accept.Clear();
                        tm.teacher_id =Convert.ToInt32(id);
                        HttpResponseMessage response = await client.PostAsJsonAsync("updateTeacher",tm);
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            JObject o = JObject.Parse(result);
                            JArray a = (JArray)o["Data"];
                            IList<Edujinni.Models.TeacherModels> person = a.ToObject<IList<Edujinni.Models.TeacherModels>>();
                            ViewBag.x = person;
                            return View("TeacherView");
                        }
                        else
                        {
                            Response.Redirect("Updation Failed Broo");
                            return RedirectToAction("TeacherView");

                        }
                    }
                    break;

                default:
                    return RedirectToAction("TeacherView", "AdminAddteacher");
                    break;
            }

        }
    }
}





