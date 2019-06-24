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
    public class WorldCupsController : Controller
    {
        private WorldCupDbEntities db = new WorldCupDbEntities();

        // GET: WorldCups
        public ActionResult Index()
        {
            return View(db.WorldCups.ToList());
        }

        // GET: WorldCups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldCup worldCup = db.WorldCups.Find(id);
            if (worldCup == null)
            {
                return HttpNotFound();
            }
            return View(worldCup);
        }

        // GET: WorldCups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorldCups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WC_Id,Location,Year")] WorldCup worldCup)
        {
            if (ModelState.IsValid)
            {
                db.WorldCups.Add(worldCup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(worldCup);
        }

        // GET: WorldCups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldCup worldCup = db.WorldCups.Find(id);
            if (worldCup == null)
            {
                return HttpNotFound();
            }
            return View(worldCup);
        }

        // POST: WorldCups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WC_Id,Location,Year")] WorldCup worldCup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worldCup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worldCup);
        }

        // GET: WorldCups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldCup worldCup = db.WorldCups.Find(id);
            if (worldCup == null)
            {
                return HttpNotFound();
            }
            return View(worldCup);
        }

        // POST: WorldCups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorldCup worldCup = db.WorldCups.Find(id);
            db.WorldCups.Remove(worldCup);
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
