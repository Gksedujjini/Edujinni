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
        //public string school_id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string email { get; set; }
        //public Int64 phone_no { get; set; }
        //public string dob { get; set; }
        //public string gender { get; set; }
        //public string subject1 { get; set; }
        //public string subject2 { get; set; }
        //public string qualification { get; set; }
        //public string teacherid { get; set; }
        //public string desigination { get; set; }
        //public string flat_no { get; set; }
        //public string street_1 { get; set; }
        //public string Builing_Name { get; set; }
        //public string street_2 { get; set; }
        //public string area { get; set; }
        //public string city { get; set; }
        //public string state { get; set; }
        //public Int32 pincode { get; set; }
        //public DateTime dateofjoining { get; set; }
        //public string image { get; set; }
        public Int16 school_id { get; set; }

        public string teacher_first_name { get; set; }
        public string teacher_last_name { get; set; }
        public string teacher_email { get; set; }
        public Int64 teacher_phone_no { get; set; }
        public string teacher_dob { get; set; }
        public string teacher_gender { get; set; }
        public string teacher_subject1 { get; set; }
        public string teacher_subject2 { get; set; }
        public string teacher_qualification { get; set; }
        public string teacher_teacherid { get; set; }
        //desigination not avaliable on teacherlist
        public string desigination { get; set; }
        public string teacher_flat_no { get; set; }
        public string teacher_street { get; set; }
        public string teacher_buildingname { get; set; }
        public string teacher_street1 { get; set; }
        public string teacher_area { get; set; }
        public string teacher_city { get; set; }
        public string teacher_state { get; set; }
        public Int32 teacher_pincode { get; set; }
        public DateTime teacher_date_of_joining { get; set; }
        public string teacher_image { get; set; }


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
