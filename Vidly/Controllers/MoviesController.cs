using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Migrations;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    /// <summary>
    /// Contains the logic for our Movie pages that is then passed to a View that corresponds to the Method's name
    /// </summary>
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        /// <summary>
        /// Initialize Database connection in Constructor
        /// </summary>
        public MoviesController()
        {
            _context = new ApplicationDbContext(); // Initialize connection to database
        }

        /// <summary>
        /// Overrides Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Loads the MovieViewModel with the list of customers into the view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var movies =
                _context.Movies.Include(m => m.GenreType)
                    .ToList(); // Sets movies equal to the list generated in the private method GetMovies();
            return View(movies);
        }

        /// <summary>
        /// Sets the movie to the Id passed and then checks if the movie exists. If not, returns an Http not found.
        /// Otherwise, it passes that specific movie to the View
        /// </summary>
        /// <param name="Id">Id passed through</param>
        /// <returns>Specific view of the movie with that movie Id</returns>
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreType)
                .SingleOrDefault(m => m.Id == id); //Lambda function to set movie equal to the Id passed through it

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        /// <summary>
        /// Sets the view to the Movie Form and loads a viewModel object that only has the genre types (as there is no movie yet created).
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModel
            {
                GenreTypes = genreTypes
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }
        
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    GenreTypes = _context.GenreTypes.ToList(),
                    Movie = movie
                };

                return View("MovieForm", viewModel);
            }

            // Checks if customer exists. If a new customer, adds it to the database, else it will update the existing customer
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
                
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.Stock = movie.Stock;
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }
    }
}