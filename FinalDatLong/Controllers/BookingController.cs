using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Navbar()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult LayoutNavbar()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return PartialView();
        }
        public ActionResult NavbarDangNhap()
        {
            return PartialView();
        }
        public ActionResult SlideShow()
        {
            return PartialView();
        }
        public ActionResult Video()
        {
            return PartialView();
        }
        public ActionResult Card()
        {
            return PartialView();
        }
        public ActionResult ProfileDoctor(int IDDoctor)
        {
          var doctor = db.Doctor.FirstOrDefault(s=>s.IDDoctor == IDDoctor);
            return View(doctor);
        }
        public ActionResult PatientProfile()
        {
      
                return PartialView();
        }
        public ActionResult NewBooking()
        {
            return PartialView();
        }
    }
}