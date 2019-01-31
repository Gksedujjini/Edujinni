using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string class1{ get; set;}
        public string section { get; set; }
        public string RoolNo { get; set; }
        public string StudentId { get; set; }
        public string AdmissionDate {get; set;}
        public DateTime Dob { get; set; }
        public string FatherName { get; set; }
        public Int64 FatherMobileNo { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public Int64 MotherMobileNo { get; set; }
        public string MotherOccupation { get; set; }
        public string SbilingName { get; set; }
        public Int32 Age { get; set; }
        public string FlatNo { get; set; }
        public string BulidingName { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AreaCode { get; set; }   //can be used for pin code in edit student 
        public string mobile { get; set; }
        public string grade { get; set; }
        public string attendance { get; set; }
        public Int32 marks { get; set; }
        public string Achievements { get; set; }
        public string Address { get; set; }
        public string Insert(StudentModel Sm)
        {
            SqlConnection con =null;
            string result ="";
            con = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("Insert into registration values(@name,@first)", con);
            return result;

        } 
        
    }
}