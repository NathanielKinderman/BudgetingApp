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
using BudgetingApp.Views;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XamarinForms.Services;
using XamarinForms.ViewModels;
using Image = Xamarin.Forms.Image;
using Label = Xamarin.Forms.Label;
using ListView = Xamarin.Forms.ListView;

namespace BudgetingApp.Controllers
{
    public class MadeActivitesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MadeActivites
        public ActionResult Index()
        {
            return View(db.MadeActivites.ToList());
        }

        // GET: MadeActivites/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            if (madeActivites == null)
            {
                return HttpNotFound();
            }
            return View(madeActivites);
        }

        // GET: MadeActivites/Create
        public ActionResult Create()
        {
            MadeActivites madeActivites = new MadeActivites();
            
            return View();
        }

        // POST: MadeActivites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NameOfActivity,LocationOfActivity,Latitude,Longitude,City,State,TimeOfActivity,HowManyMembersInvolved,EstimatedCostOfActivity")] MadeActivites madeActivites)
        {
            if (ModelState.IsValid)
            {
                string apiCall = "https://maps.googleapis.com/maps/api/geocode/json?address=" + AddPluses(madeActivites.LocationOfActivity) + ",+" + AddPluses(madeActivites.City) + ",+" + AddPluses(madeActivites.State) + "&key=AIzaSyBeWLVk14n3OzLLKLvDvUyWspH929EcEaY";
                HttpClient client = new HttpClient();
                //make a request for api call set up base address url 
                client.BaseAddress = new Uri(apiCall);
                HttpResponseMessage response = await client.GetAsync(apiCall);
                LocationInfo location = JsonConvert.DeserializeObject<LocationInfo>(await response.Content.ReadAsStringAsync());
                madeActivites.Latitude = location.Results[0].Geometry.Location.Lat.ToString();
                madeActivites.Longitude = location.Results[0].Geometry.Location.Lng.ToString();

                db.MadeActivites.Add(madeActivites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(madeActivites);
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



        // GET: MadeActivites/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            if (madeActivites == null)
            {
                return HttpNotFound();
            }
            return View(madeActivites);
        }

        // POST: MadeActivites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NameOfActivity,LocationOfActivity,Latitude,Longitude,City,State,TimeOfActivity,HowManyMembersInvolved,EstimatedCostOfActivity")] MadeActivites madeActivites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(madeActivites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(madeActivites);
        }

        // GET: MadeActivites/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            if (madeActivites == null)
            {
                return HttpNotFound();
            }
            return View(madeActivites);
        }

        // POST: MadeActivites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            db.MadeActivites.Remove(madeActivites);
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
        public ActionResult CreateEventBrite()
        {
            //EventbriteService eventbriteService = new EventbriteService();
            //await eventbriteService.GetEventsAsync("Milwaukee");
            //int x = 0;
                return View("eventBrite");

        }
         public ActionResult Map()
        {
            return View();
        }
    }
}
