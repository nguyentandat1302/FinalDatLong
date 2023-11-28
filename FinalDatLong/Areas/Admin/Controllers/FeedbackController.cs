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
            var list = from fb in db.Feedback select fb;
            return View(list);
        }
       
    }
}