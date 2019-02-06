using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    public class StudentOverView
    {
        //public byte[] student_image { get; set; }
        public string student_image { get; set; }
        public string student_first_name { get; set; }
        public string student_last_name { get; set; }
        public string student_gender { get; set;}   
        public string student_grade { get; set; }
        public string student_roll_no { get; set; }
        public string student_id { get; set; }
        public DateTime student_dob { get; set; }
        public string student_father_name { get; set; }
        public long student_father_mobile_no { get; set; }
        public string student_father_occupation { get; set; }
        public string student_mother_name { get; set; }
        public long student_mother_mobile_no { get; set; }
        public string student_mother_occupation { get; set; }
        public int student_no_of_siblings { get; set; }
        public string student_buliding_name { get; set; }
        public string Age { get; set; }
        public string student_flat_no { get; set; }
        public string BuildingName { get; set; }
        public string student_street { get; set; }
        public string student_street1 { get; set; }
        public string student_area { get; set; }
        public string student_city { get; set; }
        public string student_state { get; set; }
        public int student_pincode { get; set; }
        public string insert_by { get; set; }
        public DateTime insert_date { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }
        public DateTime student_admission_date { get; set; }
        public string Student_status { get; set; }
        public string student_class { get; set; }
        public int school_id { get; set; }
        public int class_id { get; set; }
        public string class_name { get; set; }
        public string section_name { get; set; }
        public int section_id { get; set; }
        public string studentName { get; set; }
    }
}