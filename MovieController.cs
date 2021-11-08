using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viddly2.Models;
using Viddly2.ViewModels;

namespace Viddly2.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie

        private MovieDBContext _context;

        public MovieController()
        {
            _context = new MovieDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //public ActionResult Index()
        //{
        //    var movie = new Movie() { Name = "Shrek" };
        //    var customers = new List<Customer>()
        //    {
        //       new Customer(){Name="Customer 1"},
        //       new Customer(){Name="Customer 2"}
        //    };
        //    var movieViewModel = new IndexMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(movieViewModel);
        //}

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [HttpGet]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            ViewBag.ResourceName = "New Movie";
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var existingMovie = _context.Movies.Single(m => m.Id == movie.Id);
                existingMovie.Name = movie.Name;
                existingMovie.GenreId = movie.GenreId;
                existingMovie.NumberInStock = movie.GenreId;
                existingMovie.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var genres = _context.Genres.ToList();
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = genres
                };
               ViewBag.ResourceName = "Edit Movie";
                return View("MovieForm", viewModel);
            }

        }

    }
}