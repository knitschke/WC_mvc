using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WC_mvc.Models;

namespace WC_mvc.Controllers
{
    public class PhasesController : Controller
    {
        private WorldCupDbEntities db = new WorldCupDbEntities();

        // GET: Phases
        public ActionResult Index()
        {
            var phases = db.Phases.Include(p => p.WorldCup);
            return View(phases.ToList());
        }

        // GET: Phases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = db.Phases.Find(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            return View(phase);
        }

        // GET: Phases/Create
        public ActionResult Create()
        {
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location");
            return View();
        }

        // POST: Phases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Phase_Id,PhaseName,WC_Id")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                db.Phases.Add(phase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", phase.WC_Id);
            return View(phase);
        }

        // GET: Phases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = db.Phases.Find(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", phase.WC_Id);
            return View(phase);
        }

        // POST: Phases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Phase_Id,PhaseName,WC_Id")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", phase.WC_Id);
            return View(phase);
        }

        // GET: Phases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = db.Phases.Find(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            return View(phase);
        }

        // POST: Phases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phase phase = db.Phases.Find(id);
            db.Phases.Remove(phase);
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
