using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DormDoorMan.Models;

namespace DormDoorMan.Controllers
{
    public class VisitController : Controller
    {
        private DDMDbContext db = new DDMDbContext();

        // GET: /Visit/
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Resident).Include(v => v.Visitor);
            return View(visits.ToList());
        }

        // GET: /Visit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: /Visit/Create
        public ActionResult Create()
        {
            ViewBag.ResidentID = new SelectList(db.Residents, "Id", "FullName");
            ViewBag.VisitorID = new SelectList(db.Visitors, "Id", "FullName");
            return View();
        }

        // POST: /Visit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ResidentID,VisitorID,CheckIn,CheckOut")] Visit visit)
        {
            /*visit.Resident = db.Residents.Find(visit.ResidentID);
            visit.Visitor = db.Visitors.Find(visit.VisitorID);*/
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResidentID = new SelectList(db.Residents, "Id", "FullName", visit.ResidentID);
            ViewBag.VisitorID = new SelectList(db.Visitors, "Id", "FullName", visit.VisitorID);
            return View(visit);
        }

        // GET: /Visit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResidentID = new SelectList(db.Residents, "Id", "FullName", visit.ResidentID);
            ViewBag.VisitorID = new SelectList(db.Visitors, "Id", "FullName", visit.VisitorID);
            return View(visit);
        }

        // POST: /Visit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ResidentID,VisitorID,CheckIn,CheckOut")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResidentID = new SelectList(db.Residents, "Id", "FullName", visit.ResidentID);
            ViewBag.VisitorID = new SelectList(db.Visitors, "Id", "FullName", visit.VisitorID);
            return View(visit);
        }

        // GET: /Visit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: /Visit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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
