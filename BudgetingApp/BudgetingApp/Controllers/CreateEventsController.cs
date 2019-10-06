using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BudgetingApp.Models;
using Newtonsoft.Json;

namespace BudgetingApp.Controllers
{
    public class CreateEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreateEvents
        //public ActionResult Index()
        //{

        //    var createEvents = db.CreateEvents.Where(c => c.Planner =- c);

        //    return View(createEvents.ToList());
        //}

        // GET: CreateEvents/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateEvent createEvent = db.CreateEvents.Find(id);
            if (createEvent == null)
            {
                return HttpNotFound();
            }
            return View(createEvent);
        }

        // GET: CreateEvents/Create
        public ActionResult Create()
        {
            CreateEvent createEvent = new CreateEvent();
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: CreateEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EventsName,City,Latitude,Longitude,State,DateOfEvent,NumberOfMembers,TheBudgetOfEvent,ApplicationUserId")] CreateEvent createEvent)
        {
            if (ModelState.IsValid)
            {

                string apiCall = "https://maps.googleapis.com/maps/api/geocode/json?address=" + AddPluses(createEvent.City) + ",+" + AddPluses(createEvent.State) + "&key=AIzaSyBeWLVk14n3OzLLKLvDvUyWspH929EcEaY";
                HttpClient client = new HttpClient();
                //make a request for api call set up base address url 
                client.BaseAddress = new Uri(apiCall);
                HttpResponseMessage response = await client.GetAsync(apiCall);
                LocationInfo location = JsonConvert.DeserializeObject<LocationInfo>(await response.Content.ReadAsStringAsync());
                createEvent.Latitude = location.Results[0].Geometry.Location.Lat.ToString();
                createEvent.Longitude = location.Results[0].Geometry.Location.Lng.ToString();

                db.CreateEvents.Add(createEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", createEvent.PlannerId);
            return View(createEvent);
        }

        public string AddPluses(string str)
        {
            str = str.Replace(" ", "+");
            return str;
        }

        public string AddCommas(string str)
        {
            str = str.Replace(str, ",");
            return str;

        }


        // GET: CreateEvents/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateEvent createEvent = db.CreateEvents.Find(id);
            if (createEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", createEvent.PlannerId);
            return View(createEvent);
        }

        // POST: CreateEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventsName,City,Latitude,Longitude,State,DateOfEvent,NumberOfMembers,TheBudgetOfEvent,ApplicationUserId")] CreateEvent createEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", createEvent.PlannerId);
            return View(createEvent);
        }

        // GET: CreateEvents/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateEvent createEvent = db.CreateEvents.Find(id);
            if (createEvent == null)
            {
                return HttpNotFound();
            }
            return View(createEvent);
        }

        // POST: CreateEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateEvent createEvent = db.CreateEvents.Find(id);
            db.CreateEvents.Remove(createEvent);
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
