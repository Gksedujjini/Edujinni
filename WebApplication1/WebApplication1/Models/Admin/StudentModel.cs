using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    //public class StudentModel
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Gender { get; set; }
    //    public string class1{ get; set;}
    //    public string section { get; set; }
    //    public string RoolNo { get; set; }
    //    public string student_id { get; set; }
    //    public string AdmissionDate {get; set;}
    //    public DateTime Dob { get; set; }
    //    public string FatherName { get; set; }
    //    public Int64 FatherMobileNo { get; set; }
    //    public string FatherOccupation { get; set; }
    //    public string MotherName { get; set; }
    //    public Int64 MotherMobileNo { get; set; }
    //    public string MotherOccupation { get; set; }
    //    public string SbilingName { get; set; }
    //    public Int32 Age { get; set; }
    //    public string FlatNo { get; set; }
    //    public string BulidingName { get; set; }
    //    public string street1 { get; set; }
    //    public string street2 { get; set; }
    //    public string Area { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }
    //    public string AreaCode { get; set; }   //can be used for pin code in edit student 
    //    public string mobile { get; set; }
    //    public string grade { get; set; }
    //    public string attendance { get; set; }
    //    public Int32 marks { get; set; }
    //    public string Achievements { get; set; }
    //    public string Address { get; set; }
    //    public string student_class { get; set; }
    //    public int school_id { get; set; }
    //    public int class_id { get; set; }
    //    public string class_name { get; set; }
    //    public string section_name { get; set; }
    //    public int section_id { get; set; }
    //    public string studentName { get; set; }
    //    //public string Insert(StudentModel Sm)
    //    //{
    //    //    SqlConnection con =null;
    //    //    string result ="";
    //    //    con = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=true");
    //    //    SqlCommand cmd = new SqlCommand("Insert into registration values(@name,@first)", con);
    //    //    return result;

    //    //} 
    public class StudentModel
    {
        public string Address { get; set; }
        public string Achievements { get; set; }
        public Int32 marks { get; set; }
        public int school_id { get; set; }
        public string class1 { get; set; }
        public DateTime student_admission_date { get; set; }
        public string student_area { get; set; }
        public string student_buliding_name { get; set; }
        public int student_chiled_no { get; set; }
        public string student_city { get; set; }
        public DateTime student_dob { get; set; }
        public long student_father_mobile_no { get; set; }
        public string student_father_name { get; set; }
        public string student_father_occupation { get; set; }
        public string student_first_name { get; set; }
        public string student_flat_no { get; set; }
        public string student_gender { get; set; }
        public string student_image { get; set; }
        public string student_last_name { get; set; }
        public long student_mother_mobile_no { get; set; }
        public string student_mother_name { get; set; }
        public string student_mother_occupation { get; set; }
        public int student_no_of_siblings { get; set; }
        public int student_pincode { get; set; }
        public string student_roll_no { get; set; }
        public string student_admission_id { get; set; }
        public string student_section { get; set; }
        public string student_state { get; set; }
        public string Student_status { get; set; }
        public string student_street { get; set; }
        public string student_street1 { get; set; }
        public int student_id { get; set; }
        public int class_id { get; set; }
        public int section_id { get; set; }
        public string grade { get; set; }
        public string attendance { get; set; }
    }

    public class RootObject
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<StudentModel> Data { get; set; }
    }

}