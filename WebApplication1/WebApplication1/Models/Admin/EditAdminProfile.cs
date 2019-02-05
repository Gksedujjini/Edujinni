using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edujinni.Models
{
    public class EditAdminProfile
    {
        public string PrincipalId { get; set; }
        public string SchoolName { get; set; }
        public string Email { get; set; }
        public Int64 PhoneNo { get; set; }
        public string Gender { get; set; }
        public string FlatNO { get; set; }
        public string Street { get; set; }
        public string AreaCityState { get; set; }
        public Int32 PinCode { get; set; }
        public string SchoolAddrFlatNO { get; set; }
        public string SchoolAddrStreet { get; set; }
        public Int64 SchoolPhoneNo { get; set; }
        public string SchoolAddrAreaCityState { get; set; }
        public Int32 SchoolAddrePinCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}