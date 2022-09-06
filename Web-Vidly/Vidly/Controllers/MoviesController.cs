using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = _context.Movies;


         
            return View(movie);
        }

        
        public ActionResult Page(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (sortBy.IsNullOrWhiteSpace())
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex = {0}&sortBy = {1}", pageIndex, sortBy));
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            var movie = _context.Movies.Include(m => m.Genre);



            return View("ReadOnlyList");

            /* var movies = new List<Movie> {new Movie {Name = "Shrek!"}, new Movie{Name = "Wille"}};



             var viewModel = new MovieViewModel() {Movies = movies};*/
            //return View(viewModel);
        }

        public ActionResult MovieDetail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieGenreViewModel
                {
                    Genres = _context.Genres,
                    Movie = movie
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
           
                _context.Movies.Add(movie);
            

            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.AddDate = movie.AddDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.NumberAvaliable = movie.NumberInStock;

            }
            try
            {
                
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
          
            var viewModel = new MovieGenreViewModel
            {
               Movie = new Movie(),
                Genres = _context.Genres

            };
            return View("MovieForm",viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieGenreViewModel()
            {
                Movie = movie,
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }

    }
}