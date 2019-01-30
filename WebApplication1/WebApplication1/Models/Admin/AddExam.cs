using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    public class AddExam
    {
        public string classs { get; set; }
        public string section { get; set; }
        public string examtype { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
    }
}