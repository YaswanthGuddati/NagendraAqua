using NagendraAqua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NagendraAqua.Controllers
{
    public class AdminController : Controller
    {
        AdminDAL adal = new AdminDAL();

        // LOGIN PAGE
        public ActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            // STOP if validation fails
            if (!ModelState.IsValid)
            {
                ViewBag.LoginError = null;   // Clear login error
                return View(a);
            }

            bool status = adal.AdminLogin(a);

            if (status)
            {
                Session["Admin"] = a.SellerName;
                return RedirectToAction("Dashboard");
            }

            // Only add this if model is valid
            ViewBag.LoginError = "Invalid Username or Password";

            return View(a);
        }


        // DASHBOARD
        public ActionResult Dashboard()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            return View();
        }

        // LOGOUT
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}