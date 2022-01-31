using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class RentController : ApiController
    {
        private ApplicationDbContext _context;

        public RentController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        //GET /api/rent
        public IHttpActionResult GetRental()
        {
            var rental = _context.Rentals
                .Include(r => r.Customer)
                .Include(r=>r.Movie)
                .Select(Mapper.Map<Rental, RentalDto>);
            return Ok(rental);
        }
        [HttpPost]
        //POST /api/rent
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            var customer = _context.Customers
                .Single(c => c.Id == rentalDto.CustomerId);
            var movies = _context.Movies
                .Where(m=> rentalDto.MovieIds.Contains(m.Id));
            foreach (var movie in movies)
            {
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRental = DateTime.Now
                };
                
                _context.Rentals.Add(rental);
            }
            
            _context.SaveChanges();

            return Ok();
        }//POST action is combining Edit/Save in MVController
    }
}
