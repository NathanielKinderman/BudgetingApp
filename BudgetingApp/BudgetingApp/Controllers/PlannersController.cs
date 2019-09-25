using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetingApp.Models;

namespace BudgetingApp.Controllers
{
    public class PlannersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Planners
        public ActionResult Index()
        {
            return View(db.Planners.ToList());
        }

        // GET: Planners/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner planner = db.Planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // GET: Planners/Create
        public ActionResult Create()
        {
            Planner planner = new Planner();
            return View();
        }

        // POST: Planners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,EmailAddress,Budget,ApplicationUserId")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                db.Planners.Add(planner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planner);
        }

        // GET: Planners/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner planner = db.Planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // POST: Planners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,EmailAddress,Budget,ApplicationUserId")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Planners");
            }
            return View(planner);
        }

        // GET: Planners/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner planner = db.Planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // POST: Planners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Planner planner = db.Planners.Find(id);
            db.Planners.Remove(planner);
            db.SaveChanges();
            return RedirectToAction("Index","Planners");
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
