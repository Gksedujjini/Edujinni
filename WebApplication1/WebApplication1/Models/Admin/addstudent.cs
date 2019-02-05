using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Edujinni.Models
{
    public class addstudent
    {
        public int student_id { get; set; }
        public string student_image { get; set; }
        public string student_section { get; set; }
        [Required(ErrorMessage ="Please Enter First Name")]
        public string student_first_name { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string student_last_name { get; set; }
        public string student_roll_no { get; set; }
        public int student_chiled_no { get; set; }
        [Required(ErrorMessage = "Please Select the Date Of Birth")]
        public DateTime student_dob { get; set; }
        [Required(ErrorMessage = "Please Select the Gender")]
        public string student_gender { get; set; }
        [Required(ErrorMessage = "Please Enter Father Name")]
        public string student_father_name { get; set; }
        [Required(ErrorMessage ="Please Enter the Father Mobile Number")]
       // [StringLength(10,MinimumLength =10,ErrorMessage ="Invalid Mobile Number")]
        public long student_father_mobile_no { get; set; }
        [Required(ErrorMessage ="Please Enter Father Occupation")]
        public string student_father_occupation { get; set; }
        [Required(ErrorMessage ="Please Enter Mother Name")]
        public string student_mother_name { get; set; }
        [Required(ErrorMessage = "Please Enter the Father Mobile Number")]
       // [StringLength(10, MinimumLength = 10, ErrorMessage = "Invalid Mobile Number")]
        public long student_mother_mobile_no { get; set; }
        [Required(ErrorMessage = "Please Enter Mother Occupation")]
        public string student_mother_occupation { get; set; }
        public int student_no_of_siblings { get; set; }
        [Required(ErrorMessage ="Please Enter Student Flat No.")]
        public string student_flat_no { get; set; }
        public string student_buliding_name { get; set; }
        [Required(ErrorMessage ="Please Enter Student Street Name")]
        public string student_street { get; set; }
        public string student_street1 { get; set; }
        [Required(ErrorMessage = "Please Enter Student Area Name")]
        public string student_area { get; set; }
        [Required(ErrorMessage = "Please Enter Student City Name")]
        public string student_city { get; set; }
        [Required(ErrorMessage = "Please Enter Student State Name")]
        public string student_state { get; set; }
        [Required(ErrorMessage = "Please Enter Student Pincode")]
       //s [StringLength(6,MinimumLength =6,ErrorMessage ="Invalid Pincode")]
        public int student_pincode { get; set; }
        public string insert_by { get; set; }
        public DateTime insert_date { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
        public DateTime student_admission_date { get; set; }
        public int school_id { get; set; }
        public string Student_status { get; set; }
        public string student_class { get; set; }
        public int class_id { get; set; }
        public string class_name { get; set; }
        public string section_name { get; set; }
        public int section_id { get; set; }
        public string studentName { get; set; }
  
    }
    
}