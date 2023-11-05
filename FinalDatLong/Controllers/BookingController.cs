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
        public ActionResult DoctorProfile()
        {
            return PartialView();
        }
    }
}