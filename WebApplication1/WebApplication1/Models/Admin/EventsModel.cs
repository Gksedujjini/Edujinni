using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Edujinni.Models
{
    public class EventsModel
    {
        public string EventDate { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
    }
}