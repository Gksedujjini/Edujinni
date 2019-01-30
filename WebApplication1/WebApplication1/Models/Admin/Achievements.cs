using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Edujinni.Models
{
    public class Achievements
    {

        [Required(ErrorMessage = "Please Select AchievementDate")]
        public string AchievementDate { get; set; }
        [Required(ErrorMessage = "Please Select Class")]
        public string classs { get; set;}
        [Required(ErrorMessage = "Please Select Section")]
        public string section { get; set; }
        [Required(ErrorMessage = "Please Select Student List")]
        public string studentlist { get; set; }
        [Required(ErrorMessage = "Please Enter AchievementType")]
        public string AchievementType { get; set; }
        [Required(ErrorMessage = "Please Enter Comment")]
        public string Comment { get; set; }
    }
}