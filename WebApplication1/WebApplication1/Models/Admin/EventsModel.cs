using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    public class EventsModel
    {
        [Required(ErrorMessage ="Please Select Event Date")]
        public DateTime event_date { get; set; }
        [Required(ErrorMessage = "Please Enter Event Description")]
        public string event_description { get; set; }
        public string event_image { get; set; }
        [Required(ErrorMessage ="Please Enter Event Name")]
        public string event_name { get; set; }
        public int school_id { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public string[] Data { get; set; }
        public int event_id { get; set; }
    }
    public class Datum
    {
        public DateTime event_date { get; set; }
        public string event_description { get; set; }
        public string event_image { get; set; }
        public string event_name { get; set; }
        public int school_id { get; set; }
        public int event_id { get; set;}
            
        }
    //public class RootObject
    //{
    //    public int code { get; set; }
    //    public string message { get; set; }
    //    public List<Datum> Data { get; set; }
    //}
}