using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace Edujinni.Models
{
    public class addclass
    {
        //public string class_name { get; set; } 
        [Required(ErrorMessage ="Please Enter ClassName")]
        public string class_name { get; set; }
        [Required(ErrorMessage ="Please Enter SectionName")]
        public string class_section_name { get; set; }
        [Required(ErrorMessage ="Please Select TeacherName")]
        public string teacher_id { get; set; }
        public object ViewBag { get;  set; }

        //FOR GETTING THE DETAILS
        public async void gettingdetails()
        {
            var model = new addclass();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.edujinni.in/");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    

            HttpResponseMessage response = client.GetAsync("classNames/classDetailsList").Result;  // Blocking call!  
            var cname = response.Content.ReadAsStringAsync().Result;
            /* if (response.IsSuccessStatusCode)
             {
                 //string classTeacher = "";

                 //var tnames = new List<string>();
                 //{
                 //    tnames.Add(cname);
                 //}
                 //ViewBag.class_name = tnames;
                 //TempDataDictionary.
                 //model.class_name = tnames;
             }*/
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<string>>();
                //if (result != null)
                    //model.class_name = result;
            }
            else
            {
                //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        //FOR POSTING THE DETAILS
        [HttpPost]
        public void addingdetails()
        {
             using (var client = new HttpClient())
                {
                addclass p = new addclass { class_name="dd", class_section_name = "dazzle", teacher_id = "5"};
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               // WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                var response = client.PostAsJsonAsync("addingClassDetails/addingClassDetails", p).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                    else
                        Console.Write("Error");
                }
           
        }
    }
}