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
        public ActionResult Dakhoa()
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == "Đa khoa" select doctor;
            return View(listDoctor);
        }
        public ActionResult Nhakhoa()
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == "Nha khoa" select doctor;
            return View(listDoctor);
        }
        public ActionResult Dalieu()
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == "Da lieu" select doctor;
            return View(listDoctor);
        }
        public ActionResult Nhankhoa()
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == "Nhãn khoa" select doctor;
            return View(listDoctor);
        }
        public ActionResult Phukhoa()
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == "Phu khoa" select doctor;
            return View(listDoctor);
        }
        public ActionResult Cotsong()
        {
            var listDoctor = from doctor in db.Doctor where doctor.Specialization == "Than kinh cot song" select doctor;
            return View(listDoctor);
        }
    }
}