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
    public class GamesController : Controller
    {
        private WorldCupDbEntities db = new WorldCupDbEntities();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Country).Include(g => g.Country1).Include(g => g.Group).Include(g => g.WorldCup);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.Country_Id1 = new SelectList(db.Countries, "Country_Id", "Name");
            ViewBag.Country_Id2 = new SelectList(db.Countries, "Country_Id", "Name");
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name");
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Game_Id,Score1_90,Score2_90,Score1_120,Score2_120,PK1,PK2,Group_Id,WC_Id,Country_Id1,Country_Id2")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_Id1 = new SelectList(db.Countries, "Country_Id", "Name", game.Country_Id1);
            ViewBag.Country_Id2 = new SelectList(db.Countries, "Country_Id", "Name", game.Country_Id2);
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name", game.Group_Id);
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", game.WC_Id);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_Id1 = new SelectList(db.Countries, "Country_Id", "Name", game.Country_Id1);
            ViewBag.Country_Id2 = new SelectList(db.Countries, "Country_Id", "Name", game.Country_Id2);
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name", game.Group_Id);
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", game.WC_Id);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Game_Id,Score1_90,Score2_90,Score1_120,Score2_120,PK1,PK2,Group_Id,WC_Id,Country_Id1,Country_Id2")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_Id1 = new SelectList(db.Countries, "Country_Id", "Name", game.Country_Id1);
            ViewBag.Country_Id2 = new SelectList(db.Countries, "Country_Id", "Name", game.Country_Id2);
            ViewBag.Group_Id = new SelectList(db.Groups, "Group_Id", "Name", game.Group_Id);
            ViewBag.WC_Id = new SelectList(db.WorldCups, "WC_Id", "Location", game.WC_Id);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
