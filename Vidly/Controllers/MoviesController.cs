using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(i => i.Genre).ToList();
            return View(movies);
        }

        // GET: Movies/Details
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(i => i.Genre).SingleOrDefault(i => i.Id == Id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.Include(i => i.Genre).SingleOrDefault(i => i.Id == Id);

            if(movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                GenreId = movie.GenreId,
                Genres = _context.Genres.ToList(),
                ReleaseDate = movie.ReleaseDate,
                NumInStock = movie.NumInStock
            };
            return View("MovieForm", viewModel);
        }


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
           
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                   Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
                
            if (movie.Id == 0)
            {
                
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(i => i.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumInStock = movie.NumInStock;

            }
                
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}