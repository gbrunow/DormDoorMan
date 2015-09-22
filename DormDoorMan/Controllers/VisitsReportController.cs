﻿using System;
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
    public class VisitsReportController : Controller
    {
        private DDMDbContext db = new DDMDbContext();

        // GET: /VisitsReport/
        public ActionResult Index()
        {
            var residents = db.Residents.ToList();
            List<VisitsReportViewModel> report = new List<VisitsReportViewModel>();
            foreach (var resident in residents)
            {
                VisitsReportViewModel item = new VisitsReportViewModel();
                var monthAgo = DateTime.Now.Date.AddMonths(-1);
                var visits = db.Visits.Where(v => v.ResidentID == resident.Id && v.CheckIn >= monthAgo);
                double days = 0;
                foreach(var visit in visits)
                {
                    days += visit.VisitTime; 
                }
                item.hostingDays = (int)days;
                item.extraDays = days > 4 ? (int) days - 4 : 0;

                
                item.Resident = resident;
                
                int extraDays = item.hostingDays > 4 ? item.hostingDays - 4 : 0;
                item.hostingFees = extraDays * 20;
                report.Add(item);
            }
            return View(report);
        }

        // GET: /VisitsReport/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitsReportViewModel visitsreportviewmodel = db.VisitsReportViewModels.Find(id);
            if (visitsreportviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(visitsreportviewmodel);
        }

        // GET: /VisitsReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VisitsReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id")] VisitsReportViewModel visitsreportviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.VisitsReportViewModels.Add(visitsreportviewmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitsreportviewmodel);
        }

        // GET: /VisitsReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitsReportViewModel visitsreportviewmodel = db.VisitsReportViewModels.Find(id);
            if (visitsreportviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(visitsreportviewmodel);
        }

        // POST: /VisitsReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id")] VisitsReportViewModel visitsreportviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitsreportviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitsreportviewmodel);
        }

        // GET: /VisitsReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitsReportViewModel visitsreportviewmodel = db.VisitsReportViewModels.Find(id);
            if (visitsreportviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(visitsreportviewmodel);
        }

        // POST: /VisitsReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitsReportViewModel visitsreportviewmodel = db.VisitsReportViewModels.Find(id);
            db.VisitsReportViewModels.Remove(visitsreportviewmodel);
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
        }*/
    }
}