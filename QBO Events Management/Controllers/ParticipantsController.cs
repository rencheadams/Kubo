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

        // GET: Participants
        public ActionResult Index()
        {
            var participants = db.Participants.Include(p => p.Person);
            return View(participants.ToList());
        }

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

        // GET: Participants/Create
        public ActionResult Create(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string events = "https://www.eventbriteapi.com/v3/events/"+ID+"/?token=LHPV67GP4XI26S4J5YUE";

            var json = new WebClient().DownloadString(events);

            Event e = JsonConvert.DeserializeObject<Event>(json);

            //JArray items = (JArray)test[json];
            //items.Count();

            return View(e.ID);
            //ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName");
            //return View();
        }
        

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participant participant)
        {
            /*
            if (ModelState.IsValid)
            {
                db.Participants.Add(participant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", participant.PersonID);
            return View(participant);
            */
            
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

            var events = new Event
            {
                ID = participant.Event.ID
            };

            var participants = new Participant
            {
                EventsID = participant.EventsID
            };

            using (var context = new ApplicationDbContext())
            {
                var person2 = db.People.FirstOrDefault(m => m.Email == person.Email);

                if (person2 == null)
                {
                    context.People.Add(person);
                    participant.PersonID = person.PersonID;
                }
                else
                {
                    var personID = db.People.FirstOrDefault(m => m.Email == person.Email).PersonID;
                    participant.PersonID = personID;
                }

                participant.Timestamp = DateTime.Now;
                participant.HasAttended = true;
                participant.EventsID = events.ID;
                context.Participants.Add(participant);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Participants/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", participant.PersonID);
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticipantID,PersonID,HasAttended,Email,EventsID,Timestamp")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", participant.PersonID);
            return View(participant);
        }

        // GET: Participants/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
            db.SaveChanges();
            return RedirectToAction("Index");
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
