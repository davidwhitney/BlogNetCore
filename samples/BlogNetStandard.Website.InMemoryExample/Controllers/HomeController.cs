using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogNetStandard.DataModel;
using Microsoft.AspNetCore.Mvc;
using BlogNetStandard.Website.InMemoryExample.Models;

namespace BlogNetStandard.Website.InMemoryExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContentClient _client;

        public HomeController(ContentClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            var bucket = _client.Session.Load<ContentBucket>(Identity.Default()).Single();
            

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
