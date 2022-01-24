using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        private MovieContext _blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            _blahContext = someName; //I called this blahContext because that's how it was done in the videos
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet("MovieSubmitModel")]
        public IActionResult SubmitMovie()
        {
            return View();
        }

        [HttpPost("MovieSubmitModel")]
        public IActionResult SubmitMovie(MovieSubmitModel MovieSubmission)
        {
            _blahContext.Add(MovieSubmission);
            _blahContext.SaveChanges();

            return View("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
