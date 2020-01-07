using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IQMVCProject.Models.DBContext;


namespace IQMVCProject.Controllers
{
    public class LoginController : Controller
    {
      

        public LoginController()
        {

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users loginViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(loginViewModel.Email) && !string.IsNullOrEmpty(loginViewModel.Password))
                {
                    var Username = loginViewModel.Email;
                    var password = loginViewModel.Password;
                   // var result = new LoginHelper().isValidUser(Username, password);

                    // var result = _ILogin.ValidateUser(Username, password);

                   // if (result != null)
                    {
                        //remove_Anonymous_Cookies(); //Remove Anonymous_Cookies

                        //HttpContext.Session.SetString("UserID", Convert.ToString(result.UserId));
                       // var userName = result.FirstName + " " + result.LastName;
                        //HttpContext.Session.SetString("Username", Convert.ToString(userName));
                        return RedirectToAction("Dashborad", "Home");
                    }
                }
                else
                {
                    ViewBag.errormessage = "Entered Invalid Username and Password";
                    return View();
                }

               // return View();

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                CookieOptions option = new CookieOptions();

                if (Request.Cookies["EventChannel"] != null)
                {
                    option.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Append("EventChannel", "", option);
                }

                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
            catch (Exception)
            {
                throw;
            }

        }

        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            if (Request.Cookies["EventChannel"] != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("EventChannel", "", option);
            }
        }

    }
}
