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
    public class HomeController : Controller
    {
        private MoviesAppEntities db = new MoviesAppEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.Movies.ToList());
        }
        public ActionResult AboutUs()
        {


            return View();
        }
        public ActionResult Contact()
        {


            return View();
        }

        public ActionResult SignUp()
        {


            return View();
        }
    }
}
