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
        // GET: AdminAddEvents
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
        //public ActionResult AddEvents(EventsModel updatedetails)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://www.edujinni.in/updatingEvents");
        //        var upd = client.PostAsJsonAsync<EventsModel>("updatingEvents",updatedetails);
        //        updatedetails.school_id = 1;
        //        upd.Wait();
        //        //var result = 
        //    }
        //        return View("ViewEvents");
        //}
        [HttpPost]
        public ActionResult AddEvents(EventsModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.edujinni.in/addingEvents");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<EventsModel>("addingEvents", model);
                model.school_id = 1;
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {                    
                    Response.Write("<script>alert('Event Created successfully')</script>");
                    return RedirectToAction("ViewEvents");
                }
            }
            Response.Write("<script>Error adding the Event</script>");
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(model);
        }
    }
}