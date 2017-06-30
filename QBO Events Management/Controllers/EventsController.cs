using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QBO_Events_Management.Models;
//using Eventbrite.LinqProvider;
//using EventbriteService;
using System.Web.Script.Serialization;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace QBO_Events_Management.Controllers
{

	[Authorize(Roles = "Admin")]
	public class EventsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();


		public ActionResult ListOfEvents()
		{
			string organizer = "https://www.eventbriteapi.com/v3/organizers/14330786176/events/?token=RHB5LVF477QSIZN4JYP5";

			var json = new WebClient().DownloadString(organizer);

			EventBrite e = JsonConvert.DeserializeObject<EventBrite>(json);
			
			return View(e.Events);

			//e.Events.ForEach()
			////get num of attendees
			//string attendees = "https://www.eventbriteapi.com/v3/events/" + id + "/attendees/?token=RHB5LVF477QSIZN4JYP5";
			//var json2 = new WebClient().DownloadString(attendees);
			//EventBrite e = JsonConvert.DeserializeObject<EventBrite>(json2);

			//int length = e.Attendees.Count();
			//ViewBag.Length = length;


			//EventbriteContext context = new EventbriteContext("RHB5LVF477QSIZN4JYP5");
			//// find a list of attendees for an event by supplying an id of the requested event.
			//var attendees = context.Client.EventAttendees(35474832178);

			//var events = context.Client.GetEvent(35474832178);
			////var venue = context.Client.GetVenue(35474832178);
			//JavaScriptSerializer json = new JavaScriptSerializer();

			//ViewBag.Attendees = json.Serialize(attendees);
			//ViewBag.Events = events;

			//string api = @"https://www.eventbriteapi.com/v3/events/35474832178/attendees/?token=RHB5LVF477QSIZN4JYP5";

			//var json = new WebClient().DownloadString(api);
			//var format = JObject.Parse(json);


			//var name = (string)format["attendees"][0]["profile"]["first_name"];

			//ViewBag.Attendees = name;



			//dynamic GetEventId = JObject.Parse(json);

			// GetEventId.response.events.id;
			//int id = GetEventId.GetObject().GetNamedNumber("id");

			//var jss = new JavaScriptSerializer();

			//var dict = jss.Deserialize<dynamic>(json);
			//string organizer = "https://www.eventbriteapi.com/v3/organizers/14330786176/events/?token=RHB5LVF477QSIZN4JYP5";

			//var json = new WebClient().DownloadString(organizer);

			//var format = JObject.Parse(json);


			//var EventsId = (string)format["events"]["id"];



			//ViewBag.OrgId = EventsId;



			//string Event = "https://www.eventbriteapi.com/v3/events/" + EventsId + "/attendees/?token=RHB5LVF477QSIZN4JYP5";

			//var json2 = new WebClient().DownloadString(Event);

			//var format2 = JObject.Parse(json2);

			////ViewBag.Length = length;
			//int x = 0;
			//int length = (int)format2["pagination"]["object_count"];
			//List<string> Attendees = new List<string>();
			//for (int i = 0; i < length; i++)
			//{

			//	string AttendeeName = (string)format2["attendees"][x]["profile"]["name"];
			//	Attendees.Add(String.Format(AttendeeName + "{0}", x));
			//	x++;
			//	//foreach (var item in AttendeeName)
			//	//{
			//	//	Console.WriteLine(item.ToString());
			//	//}
			//	//IEnumerable<string> query = AttendeeName;
			//}

			//return View(Attendees);
		}

		public ActionResult Attendees(string id)
		{
			if (id.Equals(null))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			//EventBrite eventID = EventBrite.Equals(id);
			
			if (string.IsNullOrEmpty(id))
			{
				return HttpNotFound();
			}

			string attendees = "https://www.eventbriteapi.com/v3/events/" + id + "/attendees/?token=RHB5LVF477QSIZN4JYP5";

			var json = new WebClient().DownloadString(attendees);

			EventBrite e = JsonConvert.DeserializeObject<EventBrite>(json);
			

			//JArray items = (JArray)test[json];
			//items.Count();

			return View(e.Attendees);



			//string attendees = "https://www.eventbriteapi.com/v3/events/35474832178/attendees/?token=RHB5LVF477QSIZN4JYP5";

			//var json = new WebClient().DownloadString(attendees);

			//EventBrite e = JsonConvert.DeserializeObject<EventBrite>(json);

			//return View(e.Attendees);
		}

		public ActionResult Profile()
		{
			return View();
		}

		public ActionResult AddAttendee()
		{
			return View();
		}



		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
