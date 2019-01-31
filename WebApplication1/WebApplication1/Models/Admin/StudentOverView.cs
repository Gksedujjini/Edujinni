using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    public class StudentOverView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classs { get; set; }
        public string search { get; set; }
        public string Grade { get; set; }
        public Int64 Section { get; set; }
        public DateTime RollNO { get; set; }
        public string StudentId { get; set; }
        public string Dob { get; set; }
        public string FatherName { get; set; }
        public string FatherMobileNo { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string MotherMobileNo { get; set; }
        public string MotherOccupation { get; set; }
        public string SibblingName { get; set; }
        public string Age { get; set; }
        public string FlatNo { get; set; }
        public string BuildingName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Int32 AreaCode { get; set; }
        public int school_id { get; set; }
        public int class_id { get; set; }
        public int section_id { get; set; }
    }
}