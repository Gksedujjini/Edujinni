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

                         //************************COMPLETE STUDENTS LIST IS SHOWN***********************/
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
                ViewBag.stu = Students;
            }
            return View();
        }



                        //**************************ADDING STUDENT CODE GOES HERE****************************//


        [HttpPost]
        public async Task<ActionResult> AddStudent(addstudent model)
        {
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
            //    HttpResponseMessage classes = await client.PostAsJsonAsync("classNames/classDetailsList", model);
              //  HttpResponseMessage sections = await client.PostAsJsonAsync("sectionList", model);
                //if(classes.IsSuccessStatusCode==true)
                //{
                //    var classnames = classes.Content.ReadAsStringAsync().Result;
                //    JObject cl = JObject.Parse(classnames);
                //    JArray cll = (JArray)cl["Data"];
                //    IList<addstudent> classdetails = cll.ToObject<IList<addstudent>>();
                //    ViewBag.clsname = classdetails;
                //}
                //if(sections.IsSuccessStatusCode==true)
                //{
                //    var section = sections.Content.ReadAsStringAsync().Result;
                //    JObject s = JObject.Parse(section);
                //    JArray ss = (JArray)s["Data"];
                //    IList<addstudent> sectionnames = ss.ToObject<IList<addstudent>>();
                //    ViewBag.sectnname = sectionnames;
                //}
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
        public async Task<ActionResult> StudentInfo(int id, StudentModel studentinfo)
        {
            using (HttpClient http = new HttpClient())
            {
                //StudentModel st = new StudentModel();
                http.BaseAddress = new Uri("http://www.edujinni.in/");
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                http.DefaultRequestHeaders.Accept.Clear();
                studentinfo.school_id = 1;
                studentinfo.student_id = id;
                studentinfo.class_id = 6;
                studentinfo.section_id = 3;
                HttpResponseMessage details = await http.PostAsJsonAsync("perticularStudent", studentinfo);
                if(details.IsSuccessStatusCode == true)
                {
                    var det = details.Content.ReadAsStringAsync().Result;
                    JObject s = JObject.Parse(det);
                    JArray a = (JArray)s["Data"];
                    IList<StudentModel> list = a.ToObject<IList<StudentModel>>();
                    ViewBag.studetails = list;
                    foreach (var item in list)
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
                else
                {
                    Response.Write("<script>alert('Details Not Found')</script>");
                    return View("StudentOverView");
                }

            }
            return View();
        }       
        
                        ////////*************EDIT STUDENT CODE GOES HERE******************************/////// 

        [HttpPost]
        //public ActionResult EditStudent()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult EditStudent()
        {
            return View();
        }
       
    }
}