using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        Model1 db = new Model1();

        // GET: Admin/Feedback
        public ActionResult Index()
        {
            double AverageRating = 0;
            //so lan danh gia cua khach hang
            int TotalRatings = db.Feedback.Count(); 
            foreach (var fb in db.Feedback)
            {
                //tinh so sao trung binh
                AverageRating = db.Feedback.Sum(f => f.Rating) / (double)TotalRatings;
            }
            ViewBag.AverageRating = AverageRating;
            ViewBag.TotalRatings = TotalRatings;

            return View(db.Feedback.ToList());
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Feedback = db.Feedback.SingleOrDefault(n => n.IDFeedback == id);
            if (Feedback == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Feedback);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            var Feedback = db.Feedback.SingleOrDefault(n => n.IDFeedback == id);
            if (Feedback == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.Feedback.Remove(Feedback);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}