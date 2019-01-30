using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Edujinni.Models
{
    public class Editprofile
    {
        public string PrincipalId { get; set; }
        public string SchoolName { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Enter Proper Email Id")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]
        [StringLength(10,ErrorMessage ="Invalid Mobile Number")]
        public Int64 PhoneNo { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage ="Enter Flat No")]
        public string FlatNO { get; set; }
        public string Street { get; set; }
        [Required(ErrorMessage ="Enter Area,City,State")]
        public string AreaCityState { get; set; }
        [Required(ErrorMessage ="Enter PinCode")]
        [StringLength(6,ErrorMessage ="Enter Proper PinCode")]
        public Int32 PinCode { get; set; }
        public string SchoolAddrFlatNO { get; set; }    
        public string SchoolAddrStreet { get; set; }
        public Int64 SchoolPhoneNo { get; set; }
        public string SchoolAddrAreaCity { get; set; }
        public string SchoolAddrState { get; set; }
        public Int32 SchoolAddrePinCode { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        //[Display(Name = "Password")]
        [DisplayName("Pass")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("p")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        //[Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords MisMatch")]
        public string ConfirmPassword { get; set; }
        
    }
}
