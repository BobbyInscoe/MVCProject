using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Rental(NewRentalDto newRental)
        {
            // check if movies were selected for rental
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been givne.");

            // get customer from customer Id in database
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Customer Id is not valid.");

            // Convert movie ids into a list after grabbing movie ids from database
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            // check if all movie ids are valid
            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movie Ids are invalid.");

            
            foreach (var movie in movies)
            {
                if (movie.AvailableStock == 0)
                    return BadRequest("Movie is not available.");

                movie.AvailableStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
