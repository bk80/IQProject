
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IQMVCProject.Models;
using IQMVCProject.Interface;
using IQMVCProject.Model;
using IQMVCProject.BAL;

namespace IQMVCProject.Controllers
{
    public class InquiryController : Controller
    {
        [HttpGet]
        public ActionResult Inquiry()
        {
            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inquiry(IFormCollection fdata)
        {
            Console.Write("f" + Convert.ToString(fdata["ProductName"]));
            // Product product = new Product
            // {
            //     Id = new Random().Next(500),
            //     ProductName = Convert.ToString(fdata["ProductName"]),
            //     CustomerName = Convert.ToString(fdata["CustomerName"]),
            //     PhoneNumber = Convert.ToString(fdata["PhoneNumber"]),
            //     CustomerNotes = Convert.ToString(fdata["CustomerNotes"])
            // };
            Inquiries inquiry = new Inquiries
            {

                CustomerName = Convert.ToString(fdata["CustomerName"]),
                Email = Convert.ToString(fdata["Email"]),
                PhoneNumber = Convert.ToString(fdata["PhoneNumber"]),
                Address = Convert.ToString(fdata["Address"]),
                ProductId = 1,
                // Email = Convert.ToString(fdata["CustomerName"]),

                CustomerNotes = Convert.ToString(fdata["CustomerNotes"])
            };

            new InquiryHelper().addUpdateInquiry(inquiry);
            return RedirectToAction("Index");

        }


    }
}
