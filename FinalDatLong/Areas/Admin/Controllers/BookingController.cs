using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data.Entity.Migrations;
using System.Drawing;
using SachOnline;

namespace FinalDatLong.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        // GET: Admin/Booking
        Model1 db = new Model1();
        public ActionResult Index(int ? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.Booking.ToList().OrderBy(n => n.IDBooking).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Booking model)
        {

            if (ModelState.IsValid)
            {
                db.Booking.AddOrUpdate(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}