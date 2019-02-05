using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Edujinni.Models
{
    public class AddSection
    {
        [Required(ErrorMessage ="Please Enter Section Name")]
        public string SectionName { get; set; }
    }
}