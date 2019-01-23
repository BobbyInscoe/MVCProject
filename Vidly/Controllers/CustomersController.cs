using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    /// <summary>
    ///     Contains the logic for our Customer pages that is then passed to a View that corresponds to the Method's name
    /// </summary>
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext(); // Initialize a connection to the database
        }

        /// <summary>
        ///     Overrides the Dispose Method for DbContext. This releases all resources used by the controller when the job is
        ///     finished
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        ///     Controller for a new Customer. Loads a CustomerViewModel (that contains Customer and Enum for Membership Types)
        ///     into the View
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        /// <summary>
        ///     Save customer method. This will add the information that was posted on the New Customer page. After adding the
        ///     customer to the context, it will save
        ///     the newly created customer in to the database and redirect to the Index page in CustomersController.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            // Checks if customer exists. If a new customer, adds it to the database, else it will update the existing customer
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        /// <summary>
        ///     Loads the CustomerViewModel with the list of customers into the view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // Sets customers equal to the list generated in the private method GetCustomers();
            return View();
        }

        /// <summary>
        ///     Sets the Customer to the Id passed and then checks if the Customer exists. If not, returns an Http not found.
        ///     Otherwise, it passes that specific movie to the View
        /// </summary>
        /// <param name="Id">Id passed through</param>
        /// <returns>Specific view of the movie with that Customer Id</returns>
        public ActionResult Details(int id)
        {
            var customer =
                _context.Customers.Include(c => c.MembershipType)
                    .SingleOrDefault(c =>
                        c.Id == id); //Lambda function to set Customer equal to the Id passed through it


            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        /// <summary>
        ///     Sets the view to CustomerForm with the customer information from Customer Id loaded in.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}