using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetingApp.Models;
using BudgetingApp.Views;
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
        public ActionResult Create([Bind(Include = "NameOfActivity,LocationOfActivity,TimeOfActivity,HowManyMembersInvolved,EstimatedCostOfActivity")] MadeActivites madeActivites)
        {
            if (ModelState.IsValid)
            {
                db.MadeActivites.Add(madeActivites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(madeActivites);
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
        public ActionResult Edit([Bind(Include = "NameOfActivity,LocationOfActivity,TimeOfActivity,HowManyMembersInvolved,EstimatedCostOfActivity")] MadeActivites madeActivites)
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
        public ActionResult eventBrite()
        {
            EventbriteService eventbriteService = new EventbriteService();
            return View(eventbriteService);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult eventBrite(EventbriteService eventbriteService)
        {

            if (ModelState.IsValid)
            {
                //db.MadeActivites.Add(eventBrite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();


        }
    }
}
