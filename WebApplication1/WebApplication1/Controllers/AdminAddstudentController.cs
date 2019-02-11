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
        Edujinni.Models.StudentModel st = new Edujinni.Models.StudentModel();
        addstudent at = new addstudent();

                         //************************COMPLETE STUDENTS LIST IS SHOWN***********************/
        [HttpGet]
        public async Task<ActionResult> StudentsOverView(StudentOverView details)
        {
            List<SelectListItem> li = new List<SelectListItem>();
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
                List<Edujinni.Models.StudentOverView> p = (List<Edujinni.Models.StudentOverView>)classlist;
                foreach (var item in p)
                {
                    li.Add(new SelectListItem() { Text = item.class_name, Value = item.class_id.ToString() });
                }
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
                ViewBag.stu = Students;
            }
            return View();
        }



                        //**************************ADDING STUDENT CODE GOES HERE****************************//


        [HttpPost]
        public async Task<ActionResult> AddStudent(addstudent model)
        {
            List<SelectListItem> li = new List<SelectListItem>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                model.school_id = 1;
                model.class_id = 5;
                model.section_id = 4;
                model.student_section = "c";
                model.student_chiled_no = 1;
                model.insert_by = "ss";
                model.insert_date = DateTime.Now;
                model.update_by = "";
                model.update_date = DateTime.Now;
                model.student_section = "c";
                model.student_admission_date = DateTime.Now;
                model.Student_status = "sai";
                model.student_class = "1st class";
                model.student_admission_id = "1234";
                model.student_password = "123";
                model.parent_password = "qqq";
                HttpResponseMessage response = await client.PostAsJsonAsync("addingStudentDetails", model);
                HttpResponseMessage classes = await client.PostAsJsonAsync("classNames/classDetailsList", model);
                HttpResponseMessage sections = await client.PostAsJsonAsync("sectionList", model);
                if (classes.IsSuccessStatusCode == true)
                {
                    var classnames = classes.Content.ReadAsStringAsync().Result;
                    JObject cl = JObject.Parse(classnames);
                    JArray cll = (JArray)cl["Data"];
                    IList<addstudent> classdetails = cll.ToObject<IList<addstudent>>();
                    ViewBag.clsname = classdetails;
                    List<Edujinni.Models.addstudent> p = (List<Edujinni.Models.addstudent>)classdetails;
                foreach (var item in p)
                {
                    li.Add(new SelectListItem() { Text = item.student_class, Value = item.class_id.ToString() });
                }
            }
                if (response.IsSuccessStatusCode==true)
                {
                    Response.Write("<script>alert('Student Added successfully')</script>");
                    return RedirectToAction("StudentsOverView");
                }
                else { 
                Response.Write("<script>alert('Error adding Student')</script>");
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
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
                model.class_id = 5;
                model.section_id = 4;
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


                     //***********************BASED ON SELECTION COMPLETE DETAILS IS SHOWN CODE*********************************///////

        [HttpGet]
        //public async Task<ActionResult> StudentInfo(int id, StudentModel studentinfo)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        //StudentModel st = new StudentModel();
        //        http.BaseAddress = new Uri("http://www.edujinni.in/");
        //        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        http.DefaultRequestHeaders.Accept.Clear();
        //        studentinfo.school_id = 1;
        //        studentinfo.student_id = id;
        //        studentinfo.class_id = 6;
        //        studentinfo.section_id = 3;
        //        HttpResponseMessage details = await http.PostAsJsonAsync("perticularStudent", studentinfo);
        //        if (details.IsSuccessStatusCode == true)
        //        {
        //            var det = details.Content.ReadAsStringAsync().Result;
        //            JObject s = JObject.Parse(det);
        //            JArray a = (JArray)s["Data"];
        //            IList<StudentModel> list = a.ToObject<IList<StudentModel>>();
        //            ViewBag.studetails = list;
        //            foreach (var item in list)
        //            {
        //                if (id == item.student_id)
        //                {
        //                    //Response.Write("<script>alert('Detils Found')</script>");
        //                    st.student_first_name = item.student_first_name;
        //                    st.student_last_name = item.student_last_name;
        //                    st.student_id = item.student_id;
        //                    st.class1 = item.class1;
        //                    st.student_section = item.student_section;
        //                    st.student_admission_date = item.student_admission_date;
        //                    st.student_gender = item.student_gender;
        //                    st.student_father_mobile_no = item.student_father_mobile_no;
        //                    st.student_dob = item.student_dob;
        //                    st.grade = item.grade;
        //                    st.attendance = item.attendance;
        //                    st.marks = item.marks;
        //                    st.student_father_name = item.student_father_name;
        //                    st.Achievements = item.Achievements;
        //                    st.Address = item.student_city;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('Details Not Found')</script>");
        //            return View("StudentOverView");
        //        }

        //    }
        //    return View(studentinfo);
        //}
        public ActionResult StudentInfo(int id, StudentModel studentinfo)
        {
            //Edujinni.Models.EventsModel eve = new Edujinni.Models.EventsModel();            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                studentinfo.school_id = 1;
                studentinfo.student_id = id;
                studentinfo.class_id = 6;
                studentinfo.section_id = 3;
                var upd = client.PostAsJsonAsync<StudentModel>("perticularStudent", studentinfo);
                upd.Wait();
                var result = upd.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultt = result.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(resultt);
                    JArray a = (JArray)o["Data"];
                    IList<StudentModel> events = a.ToObject<IList<StudentModel>>();
                    ViewBag.studetails = events;
                    foreach (var item in events)
                    {
                        if (id == item.student_id)
                        {
                            //Response.Write("<script>alert('Detils Found')</script>");
                            st.student_first_name = item.student_first_name;
                            st.student_last_name = item.student_last_name;
                            st.student_id = item.student_id;
                            st.class1 = item.class1;
                            st.student_section = item.student_section;
                            st.student_admission_date = item.student_admission_date;
                            st.student_gender = item.student_gender;
                            st.student_father_mobile_no = item.student_father_mobile_no;
                            st.student_dob = item.student_dob;
                            st.grade = item.grade;
                            st.attendance = item.attendance;
                            st.marks = item.marks;
                            st.student_father_name = item.student_father_name;
                            st.Achievements = item.Achievements;
                            st.Address = item.student_city;
                        }
                    }
                }
                else { Response.Write("<script>Error Retreiving</script>"); }
            }
            // Response.Write("<script>Error adding the Event</script>");
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(st);
        }
        [HttpPost]
        public ActionResult StudentInfo()
        {
            return View();
        }
        
                                            ////////*************EDIT/UPDATE STUDENT CODE GOES HERE******************************/////// 
        [HttpGet]
        public ActionResult EditStudent(string id,string name, addstudent studedetails)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                studedetails.school_id = 1;
                studedetails.student_id = id;
                studedetails.class_id = 6;
                studedetails.section_id = 3;
                var upd = client.PostAsJsonAsync<addstudent>("perticularStudent", studedetails);
                upd.Wait();
                var result = upd.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultt = result.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(resultt);
                    JArray a = (JArray)o["Data"];
                    IList<addstudent> stu = a.ToObject<IList<addstudent>>();
                    foreach (var item in stu)
                    {
                        if (id == item.student_id)
                        {
                            at.student_first_name = item.student_first_name;
                            at.student_last_name = item.student_last_name;
                            at.student_section = item.student_section;
                            at.student_admission_date = item.student_admission_date;
                            at.student_gender = item.student_gender;
                            at.student_father_mobile_no = item.student_father_mobile_no;
                            at.student_dob = item.student_dob;
                            at.student_father_name = item.student_father_name;
                            at.student_father_occupation = item.student_father_occupation;
                            at.student_mother_name = item.student_mother_name;
                            at.student_mother_mobile_no = item.student_mother_mobile_no;
                            at.student_mother_occupation = item.student_mother_occupation;
                            at.student_chiled_no = item.student_chiled_no;
                            at.student_no_of_siblings = item.student_no_of_siblings;
                            at.student_flat_no = item.student_flat_no;
                            at.student_buliding_name = item.student_buliding_name;
                            at.student_street = item.student_street;
                            at.student_area = item.student_area;
                            at.student_city = item.student_city;
                            at.student_state = item.student_state;
                            at.student_pincode = item.student_pincode;
                            at.student_roll_no = item.student_roll_no;
                            at.student_id = item.student_id;
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Error Retreiving Details');</script>");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(at);
        }
        [HttpPost]
        public async Task<ActionResult> EditStudent(string id, addstudent updatestudent)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                updatestudent.school_id = 1;
                updatestudent.student_section = "chess";
                updatestudent.student_class = "1";
                updatestudent.section_id = 3;
                updatestudent.class_id = 6;
                updatestudent.student_admission_id = "123";
                updatestudent.insert_by = "";
                updatestudent.update_by = "sai";
                updatestudent.student_admission_date = DateTime.Now;
                updatestudent.Student_status = "sai";
                HttpResponseMessage response = await client.PostAsJsonAsync("updateStudentDetails", updatestudent);
                if (response.IsSuccessStatusCode)
                {
                    Response.Write("<script>alert('Student Details Updated')</script>");
                    return RedirectToAction("StudentsOverView");
                }
                else
                {
                    Response.Write("<script>alert('Error Updating the Student')</script>");
                }
            }
            return View(updatestudent);
        }

    }
}