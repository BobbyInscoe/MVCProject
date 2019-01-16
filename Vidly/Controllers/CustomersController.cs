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
    /// Contains the logic for our Customer pages that is then passed to a View that corresponds to the Method's name
    /// </summary>
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext(); // Initialize a connection to the database
        }

        /// <summary>
        /// Overrides the Dispose Method for DbContext. This releases all resources used by the controller when the job is finished
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Loads the CustomerViewModel with the list of customers into the view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // Sets customers equal to the list generated in the private method GetCustomers();
            return View(customers);
        }

        /// <summary>
        /// Sets the Customer to the Id passed and then checks if the Customer exists. If not, returns an Http not found.
        /// Otherwise, it passes that specific movie to the View
        /// </summary>
        /// <param name="Id">Id passed through</param>
        /// <returns>Specific view of the movie with that Customer Id</returns>
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); //Lambda function to set Customer equal to the Id passed through it

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        /// <summary>
        /// Creates a private method that Generates a list of Customers for us to work with
        /// </summary>
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer {Id = 1, Name = "Rachel"},
        //        new Customer {Id = 2, Name = "Monica"},
        //        new Customer {Id = 3, Name = "Ross"},
        //        new Customer {Id = 4, Name = "Joey"},
        //        new Customer {Id = 5, Name = "Chandler"},
        //        new Customer {Id = 6, Name = "Phoebe"},
        //    };

        //}
    }
}