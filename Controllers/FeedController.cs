using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NagendraAqua.Models;


namespace NagendraAqua.Controllers
{
    public class FeedController : Controller
    {
        FeedDAL fdal = new FeedDAL();

        // ======================
        // DISPLAY FEEDS
        // ======================
        public ActionResult GetFeeds()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");

            List<Feed> feeds = fdal.GetFeeds();
            return View(feeds);
        }

        // ======================
        // CREATE
        // ======================
        public ActionResult CreateFeed()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeed(Feed f)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            fdal.InsertFeed(f);
            return RedirectToAction("GetFeeds");
        }

        // ======================
        // EDIT
        // ======================
        public ActionResult Edit(int id)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            Feed f = fdal.GetFeedById(id);
            return View(f);
        }

        [HttpPost]
        public ActionResult Edit(Feed f)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            fdal.UpdateFeed(f);
            return RedirectToAction("GetFeeds");
        }

        // ======================
        // DELETE
        // ======================
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            fdal.DeleteFeed(id);
            return RedirectToAction("GetFeeds");
        }
    }
}