using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var repo = new CustomersRepository();
            var customerList = repo.GetCustomers();
            return View(customerList);
        }

        //[HttpGet]
        //public ActionResult GetRegions(string iso3)
        //{
        //    if (!string.IsNullOrWhiteSpace(iso3) && iso3.Length == 3)
        //    {
        //        var repo = new RegionsRepository();

        //        IEnumerable<SelectListItem> regions = repo.GetRegions(iso3);
        //        return Json(regions);
        //    }
        //    return null;
        //}

        [HttpGet]
        public ActionResult GetHoliday(string year)
        {
            if (!string.IsNullOrWhiteSpace(year))
            {
                var repo = new HolidayRepository();

                var regions = repo.GetHolidays(year);
                return Json(regions);
            }
            return null;
        }

        //// GET: Customer/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Customer/Create
        //public ActionResult Create()
        //{
        //    var repo = new CustomersRepository();
        //    var customer = repo.CreateCustomer();
        //    return View(customer);
        //}

       
    }
}

