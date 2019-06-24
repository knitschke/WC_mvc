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
    public class CountryInGroupsController : Controller
    {
        private WorldCupDbEntities db = new WorldCupDbEntities();

        // GET: CountryInGroups
        public ActionResult Index()
        {
            var countryInGroups = db.CountryInGroups.Include(c => c.Country).Include(c => c.Group).Include(c => c.WorldCup);
            return View(countryInGroups.ToList());
        }

        // GET: CountryInGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryInGroup countryInGroup = db.CountryInGroups.Find(id);
            if (countryInGroup == null)
            {
                return HttpNotFound();
            }
            return View(countryInGroup);
        }

        // GET: CountryInGroups/Create
        public ActionResult Create()
        {
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name");
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name");
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location");
            return View();
        }

        // POST: CountryInGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Country_Id,Group_Id,WC_Id")] CountryInGroup countryInGroup)
        {
            if (ModelState.IsValid)
            {
                db.CountryInGroups.Add(countryInGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", countryInGroup.Country_Id);
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name", countryInGroup.Group_Id);
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", countryInGroup.WC_Id);
            return View(countryInGroup);
        }

        // GET: CountryInGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryInGroup countryInGroup = db.CountryInGroups.Find(id);
            if (countryInGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", countryInGroup.Country_Id);
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name", countryInGroup.Group_Id);
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", countryInGroup.WC_Id);
            return View(countryInGroup);
        }

        // POST: CountryInGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Country_Id,Group_Id,WC_Id")] CountryInGroup countryInGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryInGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", countryInGroup.Country_Id);
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name", countryInGroup.Group_Id);
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", countryInGroup.WC_Id);
            return View(countryInGroup);
        }

        // GET: CountryInGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryInGroup countryInGroup = db.CountryInGroups.Find(id);
            if (countryInGroup == null)
            {
                return HttpNotFound();
            }
            return View(countryInGroup);
        }

        // POST: CountryInGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryInGroup countryInGroup = db.CountryInGroups.Find(id);
            db.CountryInGroups.Remove(countryInGroup);
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
