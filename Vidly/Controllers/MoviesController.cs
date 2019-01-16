using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    /// <summary>
    /// Contains the logic for our Movie pages that is then passed to a View that corresponds to the Method's name
    /// </summary>
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext(); // Initialize connection to database
        }

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
            var movies = _context.Movies.Include(m => m.GenreType).ToList(); // Sets movies equal to the list generated in the private method GetMovies();
            return View(movies);
        }

        /// <summary>
        /// Sets the movie to the Id passed and then checks if the movie exists. If not, returns an Http not found.
        /// Otherwise, it passes that specific movie to the View
        /// </summary>
        /// <param name="Id">Id passed through</param>
        /// <returns>Specific view of the movie with that movie Id</returns>
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == Id); //Lambda function to set movie equal to the Id passed through it

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        /// <summary>
        /// Creates a private method that Generates a list of movies for us to work with
        /// </summary>
        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie {Id = 1, Name = "Shrek"},
        //        new Movie {Id = 2, Name = "Wall-E"}
        //    };
        //}
    }
}