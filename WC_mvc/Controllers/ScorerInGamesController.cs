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
    public class ScorerInGamesController : Controller
    {
        private WorldCupDbEntities db = new WorldCupDbEntities();

        // GET: ScorerInGames
        public ActionResult Index()
        {
            var scorerInGames = db.ScorerInGames.Include(s => s.Game).Include(s => s.Scorer);
            return View(scorerInGames.ToList());
        }

        // GET: ScorerInGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScorerInGame scorerInGame = db.ScorerInGames.Find(id);
            if (scorerInGame == null)
            {
                return HttpNotFound();
            }
            return View(scorerInGame);
        }

        // GET: ScorerInGames/Create
        public ActionResult Create()
        {
            ViewBag.Game_Id = new SelectList(db.Games, "Game_Id", "Game_Id");
            ViewBag.Scorer_Id = new SelectList(db.Scorers, "Scorer_Id", "Name");
            return View();
        }

        // POST: ScorerInGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Amount,Scorer_Id,Game_Id")] ScorerInGame scorerInGame)
        {
            if (ModelState.IsValid)
            {
                db.ScorerInGames.Add(scorerInGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Game_Id = new SelectList(db.Games, "Game_Id", "Game_Id", scorerInGame.Game_Id);
            ViewBag.Scorer_Id = new SelectList(db.Scorers, "Scorer_Id", "Name", scorerInGame.Scorer_Id);
            return View(scorerInGame);
        }

        // GET: ScorerInGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScorerInGame scorerInGame = db.ScorerInGames.Find(id);
            if (scorerInGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.Game_Id = new SelectList(db.Games, "Game_Id", "Game_Id", scorerInGame.Game_Id);
            ViewBag.Scorer_Id = new SelectList(db.Scorers, "Scorer_Id", "Name", scorerInGame.Scorer_Id);
            return View(scorerInGame);
        }

        // POST: ScorerInGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Amount,Scorer_Id,Game_Id")] ScorerInGame scorerInGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scorerInGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Game_Id = new SelectList(db.Games, "Game_Id", "Game_Id", scorerInGame.Game_Id);
            ViewBag.Scorer_Id = new SelectList(db.Scorers, "Scorer_Id", "Name", scorerInGame.Scorer_Id);
            return View(scorerInGame);
        }

        // GET: ScorerInGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScorerInGame scorerInGame = db.ScorerInGames.Find(id);
            if (scorerInGame == null)
            {
                return HttpNotFound();
            }
            return View(scorerInGame);
        }

        // POST: ScorerInGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScorerInGame scorerInGame = db.ScorerInGames.Find(id);
            db.ScorerInGames.Remove(scorerInGame);
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
