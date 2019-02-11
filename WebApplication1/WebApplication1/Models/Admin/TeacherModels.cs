using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using GridMvc.Html;

namespace Edujinni.Models
{
    public class TeacherModels
    {
        public int teacher_id { get; set; }
        public string  teacher_image { get; set; }
        public string teacher_first_name { get; set; }
        public string teacher_last_name { get; set; }
        public string teacher_email { get; set; }
        public string teacher_phone_no { get; set; }
        public System.DateTime teacher_dob { get; set; }
        public string teacher_gender { get; set; }
        public string teacher_subject1 { get; set; }
        public string teacher_subject2 { get; set; }
        public string teacher_qualification { get; set; }
        public string teacher_department { get; set; }
        public string teacher_flat_no { get; set; }
        public string teacher_street { get; set; }
        public string teacher_area { get; set; }
        public string teacher_city { get; set; }
        public string teacher_state { get; set; }
        public int teacher_pincode { get; set; }
        public System.DateTime teacher_date_of_joining { get; set; }
        public string insert_by { get; set; }
        public DateTime insert_date { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
        public int class_id { get; set; }
        // added for dropdownlist purpose
        public string class_name { get; set; }
        public int school_id { get; set; }
        public string teacher_teacherid { get; set; }
        public string teacher_buildingname { get; set; }
        public string teacher_street1 { get; set; }
        public string teacher_status { get; set; }
        public string teacher_fullname { get;set; }
        public string section_name { get; set; }
        public int section_id { set; get; }
        public string subject_name { get; set; }
        public int subject_id { get; set; }
    }
    //public class TeacherModels
    //{
    //    private long phone_no { get; set; }
    //    private string subject1 { get; set; }
    //    private string teacherid { get; set; }
    //    public string FirstName { get; private set; }

    //    public List<TeacherModels> Values()
    //    {
    //        var returnModel = new List<TeacherModels>();
    //        var teacher = new TeacherModels
    //        {
    //           teacherid = "ss1",
    //            FirstName = "sai",
    //            subject1 = "maths",
    //            phone_no = 8686347440
    //        };
    //        returnModel.Add(teacher);
    //        return returnModel;
    //    }
    //}
 
}
