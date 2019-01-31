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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [StringLength(10,ErrorMessage ="Invalid Mobile Number")]
        public Int64 PhoneNo { get; set; }
        [Required(ErrorMessage ="Please Select Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Flat No")]
        public string FlatNO { get; set; }
        [Required(ErrorMessage = "Please Enter Street No")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please Enter Area,City,State")]
        public string AreaCityState { get; set; }
        [Required(ErrorMessage = "Please Enter PinCode")]
        [StringLength(6,MinimumLength =6,ErrorMessage ="Please Enter Proper Pincode")]
        public Int32 PinCode { get; set; }
        public string SchoolAddrFlatNO { get; set; }    
        public string SchoolAddrStreet { get; set; }
        public Int64 SchoolPhoneNo { get; set; }
        public string SchoolAddrAreaCity { get; set; }
        public string SchoolAddrState { get; set; }
        public Int32 SchoolAddrePinCode { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        //[Display(Name = "Password")]
        [DisplayName("Pass")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        //[Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage ="Passwords MisMatch")]
        public string ConfirmPassword { get; set; }
        
    }
}
