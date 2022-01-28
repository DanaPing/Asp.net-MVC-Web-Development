using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            
           /* var customers = new List<Customer>
            {
                new Customer {Name = "Dana"},
                new Customer {Name = "Ping"}
            };
            var viewModel = new MovieViewModel()
            {
                Customers = customers
            };*/
            return View();
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes;
            var viewModel = new CustomerMembershipType
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }
        [HttpPost]//will only be accessble thru httppost
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerMembershipType
                {
                   Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            
                _context.Customers.Add(customer);//add data into database, like add migratio
            
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();//save data, like update-database
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerMembershipType()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }
    }
}