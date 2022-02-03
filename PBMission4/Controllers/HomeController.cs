using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PBMission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PBMission4.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext daContext { get; set; }

        public HomeController(MovieContext someName)
        {
            daContext = someName;
        }

        //Home
        public IActionResult Index()
        {
            return View();
        }

        //Podcasts
        public IActionResult Podcasts()
        {
            return View();
        }

        //Create a record for a movie
        [HttpGet("MovieSubmitModel")]
        public IActionResult SubmitMovie()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        [HttpPost("MovieSubmitModel")]
        public IActionResult SubmitMovie(MovieSubmitModel MovieSubmission)
        {
            if (ModelState.IsValid) //If valid
            {
            daContext.Add(MovieSubmission);
            daContext.SaveChanges();

            return View("Confirmation");
            }

            else //If Invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View(MovieSubmission);
            }
        }

        //Confirmation when creation is successful
        public IActionResult Confirmation()
        {
            return View();
        }

        //Read list of movies
        [HttpGet]
        public IActionResult MovieList()
        {
            var movieList = daContext.MovieSubmissions
                .Include(x => x.Category)
                .ToList();
            // If I wanted to filter, I would add something like:
                // .Where(movie => movie.Director == "Stephen Spielberg")
            // Just make sure that the filter happens before .ToList();
            return View(movieList);
        }

        //Update entries for movies
        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var submission = daContext.MovieSubmissions.Single(x => x.MovieId == movieid);

            return View("SubmitMovie", submission);
        }

        [HttpPost]
        public IActionResult Edit (MovieSubmitModel editedMovie)
        {    
            if (ModelState.IsValid) //If valid
            {
                daContext.Update(editedMovie);
                daContext.SaveChanges();

                return RedirectToAction("MovieList");
            }

            else //If Invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View("SubmitMovie", editedMovie);
            }
        }

        //Delete entries for a movie
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var submission = daContext.MovieSubmissions.Single(x => x.MovieId == movieid);

            return View(submission);
        }
        [HttpPost]
        public IActionResult Delete(MovieSubmitModel deletedMovie)
        {
            daContext.MovieSubmissions.Remove(deletedMovie);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
