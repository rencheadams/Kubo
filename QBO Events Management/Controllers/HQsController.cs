using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QBO_Events_Management.Models;

namespace QBO_Events_Management.Controllers
{
    public class HQsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HQs
        public ActionResult Index()
        {
            var hQs = db.HQs.Include(h => h.Person);
            return View(hQs.ToList());
        }

        // GET: HQs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HQ hQ = db.HQs.Find(id);
            if (hQ == null)
            {
                return HttpNotFound();
            }
            return View(hQ);
        }

        // GET: HQs/Create
        public ActionResult Create()
        {
            //ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName");
            return View();
        }

        // POST: HQs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HQID,PersonID,DateTime,Purpose")] HQ hQ)
        {
            if (ModelState.IsValid)
            {
                db.HQs.Add(hQ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", hQ.PersonID);
            return View(hQ);
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HQ hQ)
        {
            bool IsAdded = false;

            if (hQ == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            var person = new Person
            {
                FirstName = hQ.Person.FirstName,
                LastName = hQ.Person.LastName,
                Email = hQ.Person.Email,
                MobileNumber = hQ.Person.MobileNumber,
                Gender = hQ.Person.Gender,
                Sector = hQ.Person.Sector
            };

            var hqs = new HQ
            {
                Purpose = hQ.Purpose
            };

            using (var context = new ApplicationDbContext())
            {
                var person2 = db.People.FirstOrDefault(m => m.Email == person.Email);

                if(person2 == null)
                {
                    context.People.Add(person);
                    hqs.PersonID = person.PersonID;
                }
                else
                {
                    var personID = db.People.FirstOrDefault(m => m.Email == person.Email).PersonID;
                    hqs.PersonID = personID;
                }
                
                hqs.DateTime = DateTime.Now;
                context.HQs.Add(hqs);
                
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: HQs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HQ hQ = db.HQs.Find(id);
            if (hQ == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", hQ.PersonID);
            return View(hQ);
        }

        // POST: HQs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HQID,PersonID,DateTime,Purpose")] HQ hQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", hQ.PersonID);
            return View(hQ);
        }

        // GET: HQs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HQ hQ = db.HQs.Find(id);
            if (hQ == null)
            {
                return HttpNotFound();
            }
            return View(hQ);
        }

        // POST: HQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HQ hQ = db.HQs.Find(id);
            db.HQs.Remove(hQ);
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
