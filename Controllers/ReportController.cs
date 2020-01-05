
using System;
using Microsoft.AspNetCore.Mvc;
using IQMVCProject.BAL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IQMVCProject.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        public IActionResult Report()
        {
            getPagSizes();
            var products = new InquiryHelper().getInquiries(5);
            return View(products);

        }

        private void getPagSizes()
        {
            var templist = new List<SelectListItem>();

            for (int i = 5; i < 100; i = i + 20)
            {
                templist.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            ViewBag.pageSize = templist;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                getPagSizes();
                var products = new InquiryHelper().getInquiries(searchString);
                return View(products);
            }
            return View();

        }


    }
}
