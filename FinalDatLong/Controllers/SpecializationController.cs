using FinalDatLong.Models;
using SachOnline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Controllers
{
    public class SpecializationController : Controller
    {
        //Xong roi em nhé  da ok em cam on thay nhieu 
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
        public ActionResult ProfileDoctor(int Id)
        {
            Doctor doctor = db.Doctor.FirstOrDefault(d => d.IDDoctor == Id);
            return View(doctor);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Booking model, int id)
        {
            model.IDDoctor = id; //Gan id thoi con truong Doctor la cach de lay thong tin doctor vi trong CSDL cua ban ko co truong nay

            //model.Doctor = db.Doctor.FirstOrDefault(d => d.IDDoctor == id);
            ViewBag.doctor = db.Doctor.FirstOrDefault(d => d.IDDoctor == id);
            if (Session["UserName"] != null)
            {
                var patient = (Patient)Session["UserName"];
                // Lấy thông tin hồ sơ từ cơ sở dữ liệu dựa trên IDPatient

                if (patient != null)
                {
                    //model.Patient = patient;
                    model.IDPatient = patient.IDPatient;
                }
                else//em chay lai
                {
                    return RedirectToAction("Error");
                }
            }

            if (ModelState.IsValid)
            {
                db.Booking.Add(model);
                db.SaveChanges();
                //Em muon redirect ve action nao => _Layout la view shared ko phai action okem hieu r chay dc r a thay
                //Add thanh cong mon tra ve trang nao trang home them cai thong bao da dat he nthanh cong
                ViewBag.ThongBao = "Da dat thanh cong";
                return View(model); 
            }
            return View();
        }
    }
}