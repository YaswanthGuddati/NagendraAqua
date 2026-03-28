using NagendraAqua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NagendraAqua.Controllers
{
    public class SellerController : Controller
    {
        SellerDAL sdal = new SellerDAL();

        // LIST
        public ActionResult Getsellers()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");

            List<Seller> sellers = sdal.GetSellers();
            return View(sellers);
        }

        // CREATE (GET)
        public ActionResult CreateSeller()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSeller(Seller s)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");

            if (!ModelState.IsValid)
                return View(s);
            sdal.InsertSeller(s);
            return RedirectToAction("GetSellers");
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");

            sdal.DeleteSeller(id);
            return RedirectToAction("GetSellers");
        }
    }
}