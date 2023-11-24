using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Controllers
{
    public class SpecializationController : Controller
    {
        Model1 db = new Model1();
        // GET: Specialition
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Khoa(string Khoa)
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == Khoa select doctor;
            return View(listDoctor);
        }

        public ActionResult ProfileDoctor(string Khoa)
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == Khoa select doctor;
            return View(listDoctor);
        }
    }
}