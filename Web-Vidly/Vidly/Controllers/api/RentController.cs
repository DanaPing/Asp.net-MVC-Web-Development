using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.Ajax.Utilities;
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
        public IHttpActionResult GetRental(string query = null)
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
                .Where(m => m.NumberAvaliable > 0)
                .Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != rentalDto.MovieIds.Count)//they need be same datatype
                return BadRequest("One or more Movie is not avaliable");
            
            foreach (var movie in movies)
            {
               /* if (movie.NumberAvaliable == 0)
                    return BadRequest("Movie is not avaliable");*/
                movie.NumberAvaliable--;
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
        }
    }
}
