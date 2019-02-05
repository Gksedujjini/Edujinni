using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Edujinni.Models
{
    public class Addteacher
    {
        public int teacher_id { get; set; }
        [Required(ErrorMessage ="Please Select Profile Image")]
        public byte[] teacher_image { get; set; }
        [Required(ErrorMessage ="Please Enter First Name")]
        public string teacher_first_name { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string teacher_last_name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string teacher_email { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "Invalid Mobile Number")]
        public long teacher_phone_no { get; set; }
        [Required(ErrorMessage = "Please Select Date of Birth")]
        public System.DateTime teacher_dob { get; set; }
        [Required(ErrorMessage ="Please Select Gender")]
        public string teacher_gender { get; set; }
        [Required(ErrorMessage ="Please Enter Subject1")]
        public string teacher_subject1 { get; set; }
        [Required(ErrorMessage = "Please Enter Subject2")]
        public string teacher_subject2 { get; set; }
        [Required(ErrorMessage = "Please Enter Qualification")]
        public string teacher_qualification { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public string teacher_department { get; set; }
        [Required(ErrorMessage = "Please Enter Flat No")]
        public string teacher_flat_no { get; set; }
        [Required(ErrorMessage ="Please Enter Street")]
        public string teacher_street { get; set; }
        [Required(ErrorMessage = "Please Enter Teacher Area")]
        public string teacher_area { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string teacher_city { get; set; }
        [Required(ErrorMessage = "Please Enter State")]
        public string teacher_state { get; set; }
        [Required(ErrorMessage = "Please Enter Pincode")]
        public int teacher_pincode { get; set; }
        [Required(ErrorMessage = "Please Select Date Of Joining")]
        public DateTime teacher_date_of_joining { get; set; }
        public string insert_by { get; set; }
        public DateTime insert_date { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
        public int class_id { get; set; }
        public int school_id { get; set; }
        public string teacher_teacherid { get; set; }
        public string teacher_buildingname { get; set; }
        public string teacher_street1 { get; set; }
        // declared for update purpose
        public string teacher_fullname { get; set; }

    }
}