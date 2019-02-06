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

        [HttpPut]
        public ActionResult ViewEvents()
        {
            return View("AddEvents");
        }
        //[HttpPut]
        //public ActionResult AddEvents(string name,EventsModel updatedetails)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://www.edujinni.in/updatingEvents");
        //        var upd = client.PostAsJsonAsync<EventsModel>("updatingEvents", updatedetails);
        //        updatedetails.school_id = 1;
        //        updatedetails.event_id = 1;
        //        upd.Wait();
        //        var result = upd.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            Response.Write("<script>Event Updated Successfully</script>");
        //            return RedirectToAction("ViewEvents");
        //        }
        //        else { Response.Write("<script>Error Updating</script>"); }
        //    }
        //    Response.Write("<script>Error adding the Event</script>");
        //    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
        //    return View("ViewEvents");
        //}
        [HttpPost]
        public ActionResult AddEvents(EventsModel model)
        {
            //eve.event_date = String.Empty;
            eve.event_name = null;
            eve.event_description = null;
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

                //////EVENT UPDATING CODE GOES HERE//////
                                
               while(model.event_name!=null && model.event_name!= model.event_name)
               {
                    model.event_id = 1;
                    model.school_id = 1;
                    var putTask = client.PutAsJsonAsync<EventsModel>("updatingEvents", model);
                    putTask.Wait();
                    var putresult = putTask.Result;
                    if (putresult.IsSuccessStatusCode)
                      {
                        Response.Write("<script>alert('Event Updated successfully')</script>");
                        return RedirectToAction("ViewEvents");
                      }
                    else
                    {
                        Response.Write("<script>alert('Event Updation Failed')</script>");
                        return RedirectToAction("ViewEvents");
                    }
                }
            }            
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(model);
        }
        //[HttpGet]
        //public ActionResult AddEvents()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult AddEvents(string name, EventsModel updatedetails)
        {
            //Edujinni.Models.EventsModel eve = new Edujinni.Models.EventsModel();            
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri("http://www.edujinni.in/");
                updatedetails.school_id = 1;
                updatedetails.event_id = 1;
                updatedetails.event_name = name;
                var upd = client.PostAsJsonAsync<EventsModel>("eventsList", updatedetails);
                upd.Wait();                
                var result = upd.Result;              
                if (result.IsSuccessStatusCode)
                {
                    var resultt = result.Content.ReadAsStringAsync().Result;
                    JObject o = JObject.Parse(resultt);
                    JArray a = (JArray)o["Data"];
                    IList<EventsModel> events = a.ToObject<IList<EventsModel>>();
                    foreach(var item in events)
                    {
                        if(name== item.event_name)
                        {
                            eve.event_date = item.event_date;
                            eve.event_name = item.event_name;
                            eve.event_description = item.event_description;                            
                        }
                    }
                    //ViewBag.x = person;
                }
                else { Response.Write("<script>Error Updating</script>"); }
            }
            Response.Write("<script>Error adding the Event</script>");
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(eve);
        }
    }
}