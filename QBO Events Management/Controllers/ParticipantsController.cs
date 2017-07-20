using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QBO_Events_Management.Models;
using Newtonsoft.Json;

namespace QBO_Events_Management.Controllers
{
    public class ParticipantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /*
        // GET: Participants
        public ActionResult Index()
        {
            var participants = db.Participants.Include(p => p.Person);
            return View(participants.ToList());
        }
        */
        /*
        // GET: Participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }
        */
        // GET: Participants/Create
        public ActionResult Create(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string events = "https://www.eventbriteapi.com/v3/events/"+ID+"/?token=LHPV67GP4XI26S4J5YUE";

            var json = new WebClient().DownloadString(events);

            Participant e = JsonConvert.DeserializeObject<Participant>(json);

            return View(e);
        }
        

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participant participant)
        {
            if (participant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            var person = new Person
            {
                FirstName = participant.Person.FirstName,
                LastName = participant.Person.LastName,
                Email = participant.Person.Email,
                MobileNumber = participant.Person.MobileNumber,
                Gender = participant.Person.Gender,
                Sector = participant.Person.Sector
            };

            var participants = new Participant
            {
                EventsID = participant.EventsID
            };

            using (var context = new ApplicationDbContext())
            {
                var person2 = db.People.FirstOrDefault(m => m.Email == person.Email);

                if(person2 != null)
                {
                    var personID = db.People.FirstOrDefault(m => m.Email == person.Email).PersonID;
                    participants.PersonID = personID;
                }
                else if(person2 == null)
                {
                    context.People.Add(person);
                    participants.PersonID = person.PersonID;
                }

                participants.Timestamp = DateTime.Now;
                participants.HasAttended = true;
                context.Participants.Add(participants);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: Participants/List/5
        public ActionResult List(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var participant = db.Participants.Where(m => m.EventsID == ID).ToList();
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
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
