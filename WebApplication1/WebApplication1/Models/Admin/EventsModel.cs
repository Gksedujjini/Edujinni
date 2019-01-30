using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Edujinni.Models
{
    public class EventsModel
    {
        

        [Required(ErrorMessage ="Please select event date")]
        public string EventDate { get; set; }
        [Required(ErrorMessage = "Please enter eventname")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Please enter event description")]
        public string EventDescription { get; set; }
    }
}