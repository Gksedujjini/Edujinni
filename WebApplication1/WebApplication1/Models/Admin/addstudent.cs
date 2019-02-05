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
        //[Required(ErrorMessage = "Please Enter StudentId")]
        public int student_id { get; set; }
        [Required(ErrorMessage = "Image is mandatory")]
        public byte[] student_image { get; set; }
        [Required(ErrorMessage = "Please Select Student Section")]
        public string student_section { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        [StringLength(1)]
        public string student_first_name { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(1)]
        public string student_last_name { get; set; }
        [Required(ErrorMessage = "Please Enter Rollno")]
        public string student_roll_no { get; set; }
        [Required(ErrorMessage = "Please Enter ChaildNumber")]
        public int student_chiled_no { get; set; }
        [Required(ErrorMessage = "Please Select DateOfBirth")]
        public DateTime student_dob { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string student_gender { get; set; }
        [Required(ErrorMessage = "Enter Father Name")]
        [StringLength(5)]
        public string student_father_name { get; set; }
        [Required(ErrorMessage = "Enter Father MobileNumber")]
        [StringLength(maximumLength: 10, MinimumLength = 10)]
        public string student_father_mobile_no { get; set; }
        [Required(ErrorMessage = "Please Enter Father Occupation")]
        public string student_father_occupation { get; set; }
        [Required(ErrorMessage = "Enter Mother Name")]
        [StringLength(1)]
        public string student_mother_name { get; set; }
        [Required(ErrorMessage = "Enter Mother MobileNumber")]
        [StringLength(maximumLength: 10, MinimumLength = 10)]
        public string student_mother_mobile_no { get; set; }
        [Required(ErrorMessage = "Please Enter Mother Occupation")]
        public string student_mother_occupation { get; set; }
        [Required(ErrorMessage = "Please Enter No of Siblings")]
        public int student_no_of_siblings { get; set; }
        [Required(ErrorMessage = "Please Enter FlatNo ")]
        public string student_flat_no { get; set; }
        [Required(ErrorMessage = "Please Enter BulindingName ")]
        public string student_buliding_name { get; set; }
        [Required(ErrorMessage = "Please Enter Street")]
        public string student_street { get; set; }
        [Required(ErrorMessage = "Please Enter Street1")]
        public string student_street1 { get; set; }
        [Required(ErrorMessage ="Please Enter Area")]
        public string student_area { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string student_city { get; set; }
        [Required(ErrorMessage = "Please Enter State")]
        public string student_state { get; set; }
        [Required(ErrorMessage = "Please Enter Pincode")]
        [StringLength(6)]
        public int student_pincode { get; set; }
        
        public string insert_by { get; set; }
        public DateTime insert_date { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
        public DateTime student_admission_date { get; set; }
        public int school_id { get; set; }
        public string Student_status { get; set; }
        [Required(ErrorMessage ="Please Select Student Class")]
        public string student_class { get; set; }

        //public void GETCLASS()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://www.edujinni.in/");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    HttpResponseMessage response = client.GetAsync("classNames/classDetailsList").Result;  // Blocking call!    
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var classnames = response.Content.ReadAsStringAsync().Result;
        //    }
        //}
    }

}