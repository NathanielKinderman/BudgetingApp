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
    public class PartyMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PartyMembers
        public ActionResult Index()
        {
            return View(db.PartyMembers.ToList());
        }

        // GET: PartyMembers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyMember partyMember = db.PartyMembers.Find(id);
            if (partyMember == null)
            {
                return HttpNotFound();
            }
            return View(partyMember);
        }

        // GET: PartyMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartyMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,EmailAddress,PersonalBudget")] PartyMember partyMember)
        {
            if (ModelState.IsValid)
            {
                db.PartyMembers.Add(partyMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partyMember);
        }

        // GET: PartyMembers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyMember partyMember = db.PartyMembers.Find(id);
            if (partyMember == null)
            {
                return HttpNotFound();
            }
            return View(partyMember);
        }

        // POST: PartyMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,EmailAddress,PersonalBudget")] PartyMember partyMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partyMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partyMember);
        }

        // GET: PartyMembers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyMember partyMember = db.PartyMembers.Find(id);
            if (partyMember == null)
            {
                return HttpNotFound();
            }
            return View(partyMember);
        }

        // POST: PartyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PartyMember partyMember = db.PartyMembers.Find(id);
            db.PartyMembers.Remove(partyMember);
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
