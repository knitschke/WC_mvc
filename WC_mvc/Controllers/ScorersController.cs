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
    public class ScorersController : Controller
    {
        private WorldCupDbEntities db = new WorldCupDbEntities();

        // GET: Scorers
        public ActionResult Index()
        {
            var scorers = db.Scorers.Include(s => s.Country);
            return View(scorers.ToList());
        }

        // GET: Scorers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scorer scorer = db.Scorers.Find(id);
            if (scorer == null)
            {
                return HttpNotFound();
            }
            return View(scorer);
        }

        // GET: Scorers/Create
        public ActionResult Create()
        {
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name");
            return View();
        }

        // POST: Scorers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Scorer_Id,Name,Surname,Country_Id")] Scorer scorer)
        {
            if (ModelState.IsValid)
            {
                db.Scorers.Add(scorer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", scorer.Country_Id);
            return View(scorer);
        }

        // GET: Scorers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scorer scorer = db.Scorers.Find(id);
            if (scorer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", scorer.Country_Id);
            return View(scorer);
        }

        // POST: Scorers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Scorer_Id,Name,Surname,Country_Id")] Scorer scorer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scorer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", scorer.Country_Id);
            return View(scorer);
        }

        // GET: Scorers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scorer scorer = db.Scorers.Find(id);
            if (scorer == null)
            {
                return HttpNotFound();
            }
            return View(scorer);
        }

        // POST: Scorers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scorer scorer = db.Scorers.Find(id);
            db.Scorers.Remove(scorer);
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
