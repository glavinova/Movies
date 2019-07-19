using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesAppDatabaseFirst.Models;

namespace MoviesAppDatabaseFirst.Controllers
{
    public class ProjectionsController : Controller
    {
        private MoviesAppEntities db = new MoviesAppEntities();

        // GET: Projections
        public ActionResult Index()
        {
            var projections = db.Projections.Include(p => p.Hall).Include(p => p.Movy);
            return View(projections.ToList());
        }

        // GET: Projections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(projection);
        }

        // GET: Projections/Create
        public ActionResult Create()
        {
            ViewBag.hall_Id = new SelectList(db.Halls, "Id", "Id");
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name");
            return View();
        }

        // POST: Projections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dateTime,AvailableSits,hall_Id,MovieId")] Projection projection)
        {
            if (ModelState.IsValid)
            {
                db.Projections.Add(projection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hall_Id = new SelectList(db.Halls, "Id", "Id", projection.hall_Id);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", projection.MovieId);
            return View(projection);
        }

        // GET: Projections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            ViewBag.hall_Id = new SelectList(db.Halls, "Id", "Id", projection.hall_Id);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", projection.MovieId);
            return View(projection);
        }

        // POST: Projections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dateTime,AvailableSits,hall_Id,MovieId")] Projection projection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hall_Id = new SelectList(db.Halls, "Id", "Id", projection.hall_Id);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", projection.MovieId);
            return View(projection);
        }

        // GET: Projections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(projection);
        }

        // POST: Projections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projection projection = db.Projections.Find(id);
            db.Projections.Remove(projection);
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
