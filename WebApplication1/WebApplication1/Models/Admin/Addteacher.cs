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
        public byte[] teacher_image { get; set; }
        public string teacher_first_name { get; set; }
        public string teacher_last_name { get; set; }
        public string teacher_email { get; set; }
        public long teacher_phone_no { get; set; }
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

    }
}