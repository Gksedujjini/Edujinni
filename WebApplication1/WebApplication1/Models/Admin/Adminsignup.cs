using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    public class Adminsignup
    {

        public int guest_id { get; set; }
        [Required(ErrorMessage ="first name is required")]
        //[StringLength(10)]
        [RegularExpression(@"^[a-zA-Z ]+$")]
        public string first_name { get; set; }
        [Required]
        [StringLength(25)]
        public string last_name { get; set; }
        [Required]
        [MaxLength(10)]
        public string mobile_no { get; set; }
        [DisplayFormat(DataFormatString ="{0:d}",ApplyFormatInEditMode =true)]
        public string dateof_birth { get; set; }
        [Required]
        [StringLength(25)]
        public string create_pswd { get; set; }
        [Required]
        [Compare("create_pswd")]
        public string confirm_pswd { get; set; }
        [Required]
        [StringLength(25)]
        public string gender { get; set; }
        public string insert_by { get; set; }
        public DateTime insert_date { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }

    }
}