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
    public class MoviesController : Controller
    {
        private MoviesAppEntities db = new MoviesAppEntities();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Director).Include(m => m.Genre);
            return View(movies.ToList());
        }
        public ActionResult Search(string search)
        {
            var searchResult = db.Movies
                .Where(m =>
                m.Name.Contains(search) ||
                m.Director.Name.Contains(search)).Select(m => m)
                .ToList();
            return View("Index", searchResult);
        }
        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.Director_Id = new SelectList(db.Directors, "Id", "Name");
            ViewBag.genre_Id = new SelectList(db.Genres, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Desctiption,Duration,totalRaiting,imgUrl,Director_Id,genre_Id")] Movy movy)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Director_Id = new SelectList(db.Directors, "Id", "Name", movy.Director_Id);
            ViewBag.genre_Id = new SelectList(db.Genres, "Id", "Name", movy.genre_Id);
            return View(movy);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Director_Id = new SelectList(db.Directors, "Id", "Name", movy.Director_Id);
            ViewBag.genre_Id = new SelectList(db.Genres, "Id", "Name", movy.genre_Id);
            return View(movy);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Desctiption,Duration,totalRaiting,imgUrl,Director_Id,genre_Id")] Movy movy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Director_Id = new SelectList(db.Directors, "Id", "Name", movy.Director_Id);
            ViewBag.genre_Id = new SelectList(db.Genres, "Id", "Name", movy.genre_Id);
            return View(movy);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movy movy = db.Movies.Find(id);
            db.Movies.Remove(movy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowProjections(int id)
        {
            List<Projection> movieProjections = new List<Projection>();
           movieProjections = db.Projections
                .Where(m =>
                m.MovieId.Equals(id)).Select(m => m)
                .ToList();
            return View(movieProjections);
        }
        [HttpGet]
        public ActionResult CreateProjection()
        {
            return View();
        }
        [HttpPost ]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProjection(Projection projection)
        {
            if (ModelState.IsValid)
            {
                db.Projections.Add(projection);
                db.SaveChanges();
                return RedirectToAction("ShowProjections", new { id = projection.MovieId });
            }
            return View(projection);

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
