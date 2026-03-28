using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using NagendraAqua.Models;

namespace NagendraAqua.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAL cdal = new CustomerDAL();
        FeedDAL fdal = new FeedDAL();
        SellerDAL sdal = new SellerDAL();   // dropdown sellers

        // ===============================
        // DISPLAY ALL ORDERS
        // ===============================
        public ActionResult GetCustomers()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            DataTable dt = cdal.GetCustomers();
            return View(dt);
        }

        // ===============================
        // CREATE (GET)
        // ===============================
        public ActionResult Create()
        {
            
            LoadDropdowns();
            return View();
        }

        // ===============================
        // CREATE (POST)
        // ===============================
        
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                cdal.InsertCustomer(c);

                TempData["SuccessMessage"] = "Order placed successfully!";

                return RedirectToAction("Create"); // reload empty form
            }

            LoadDropdowns();
            return View(c);
        }

        // ===============================
        // EDIT (GET)
        // ===============================
        //public ActionResult Edit(int id)
        //{
        //    LoadDropdowns();

        //    Customer c = cdal.GetCustomerById(id);
        //    return View(c);
        //}

        //// ===============================
        //// EDIT (POST)
        //// ===============================
        //[HttpPost]
        //public ActionResult Edit(Customer c)
        //{
        //    cdal.UpdateCustomer(c);
        //    return RedirectToAction("GetCustomers");
        //}

        // ===============================
        // DELETE
        // ===============================
        public ActionResult Delete(int id)
        {
            cdal.DeleteCustomer(id);
            return RedirectToAction("GetCustomers");
        }

        // ===============================
        // LOAD DROPDOWNS
        // ===============================
        private void LoadDropdowns()
        {
            // Feed Dropdown
            List<Feed> feeds = fdal.GetFeeds();
            ViewBag.FeedList =
                new SelectList(feeds, "FeedId", "FeedName");

            // Seller Dropdown
            List<Seller> sellers = sdal.GetSellers();
            ViewBag.SellerList =
                new SelectList(sellers, "SellerId", "SellerName");
        }
    }
}