using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edujinni.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class AdminAddEventsController : Controller
    {
        Edujinni.Models.EventsModel eve = new Edujinni.Models.EventsModel();
        //GET: AdminAddEvents

                                  //********************VIEW ALL EVENTS *************//

       [HttpGet]
        public async Task<ActionResult> ViewEvents(Datum model)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                model.school_id = 1;
                HttpResponseMessage response = await client.PostAsJsonAsync("eventsList", model);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(result);
                    JArray a = (JArray)o["Data"];
                    IList<EventsModel> person = a.ToObject<IList<EventsModel>>();
                    ViewBag.x = person;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult ViewEvents()
        {
            return View();
        }

                                    //********************ADD EVENTS CODE *************//

        [HttpPost]
        public ActionResult AddEvents(EventsModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                //HTTP POST 
                model.school_id = 1;
                var postTask = client.PostAsJsonAsync<EventsModel>("addingEvents", model);
                postTask.Wait();                
                var result = postTask.Result;                
                if (result.IsSuccessStatusCode)
                {                    
                    Response.Write("<script>alert('Event Created successfully')</script>");
                    return RedirectToAction("ViewEvents");
                }
                else
                {
                    Response.Write("<script>Error adding the Event</script>");
                }
            }            
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEvents()
        {
            return View();
        }

                         /// ***********************************<UPDATE EVENTS CODE>**********************************///
                        
         [HttpGet]
         public ActionResult UpdateEvents(int id,string s, EventsModel updatedetails)
        {
            //Edujinni.Models.EventsModel eve = new Edujinni.Models.EventsModel();            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                updatedetails.school_id = 1;
                updatedetails.event_id = id;
                var upd = client.PostAsJsonAsync<EventsModel>("eventsList", updatedetails);
                upd.Wait();
                var result = upd.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultt = result.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(resultt);
                    JArray a = (JArray)o["Data"];
                    IList<EventsModel> events = a.ToObject<IList<EventsModel>>();
                    foreach (var item in events)
                    {
                        if (id == item.event_id)
                        {
                            eve.event_date = item.event_date;
                            eve.event_name = item.event_name;
                            eve.event_description = item.event_description;
                        }
                    }                   
                }
                else { Response.Write("<script>Error Retreiving</script>"); }
            }
           // Response.Write("<script>Error adding the Event</script>");
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(eve);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateEvents(int id, EventsModel updatedetails)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                updatedetails.school_id = 1;
                updatedetails.event_id = id;
                HttpResponseMessage response = await client.PostAsJsonAsync("updatingEvents", updatedetails);
                if (response.IsSuccessStatusCode)
                {
                    Response.Write("<script>alert('Events Updated')</script>");
                    return RedirectToAction("ViewEvents");
                }
                else
                {
                    Response.Write("<script>alert('Events Updation Failed')</script>");
                }

            }
            return View(updatedetails);
        }


                      ////******************************* <DELETE EVENT METHOD GOES HERE>********************************////

        public ActionResult DeleteEvent(int id, EventsModel eve)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                eve.school_id = 1;
                eve.event_id = id;
                //eve.event_name = name;
                var deleteTask = client.DeleteAsync("deletingEvents/" + id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ViewEvents");
                }
            }
            return RedirectToAction("ViewEvents");
        }
    }
}