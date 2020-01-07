using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IQMVCProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IQMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Dashborad()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Productservice(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var products = new BAL.ProductDataHandler().GetProducts(searchString);
                return View(products);
            }
            return View();

        }
        public IActionResult Productservice()
        {
            var products = new BAL.ProductDataHandler().GetProducts(5);
            return View(products);
        }
        public IActionResult Inquiriesfollowups()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inquiriesfollowups(IFormCollection fdata)
        {

            Models.DBContext.Users user = new Models.DBContext.Users
            {
                UserId = new Random().Next(),
                FirstName = Convert.ToString(fdata["FirstName"]),
                Password = Convert.ToString(fdata["Password"]),
                LastName = Convert.ToString(fdata["LastName"]),
                Address = Convert.ToString(fdata["Address"]),
                Email = Convert.ToString(fdata["FirstName"]),
                ContactNumber = Convert.ToString(fdata["ContactNumber"])

            };

            new BAL.ProductDataHandler().AddUser(user);
            return RedirectToAction("Index");

        }
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
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
