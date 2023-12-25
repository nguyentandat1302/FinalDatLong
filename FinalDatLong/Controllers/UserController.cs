using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Model1 db = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(Patient Model)
        {
            if (ModelState.IsValid)
            {
                var kh = db.Patient.FirstOrDefault(k => k.UserName == Model.UserName);
                if (kh != null)
                {
                    ModelState.AddModelError("UserName", "Ten tai Khoan ton tai");
                    return View(Model);
                }

                db.Patient.Add(Model);
                db.SaveChanges();
                return View("DangNhap");

            }


            return View(Model);


        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var u = db.Patient.FirstOrDefault(k => k.UserName == user.UserName && k.Password == user.Password);
                if (u != null)
                {
                    Session["UserName"] = u;
                    ViewBag.ThongBao = "Đăng Nhập Thành Công";
                    return Redirect("~/");
                }
                else
                {
                    ModelState.AddModelError("Password", "Error WrongPassword");
                }
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Booking");
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(Feedback Model)
        {
            //ViewBag.List = from fb in db.Feedback select fb;
            var u = (Patient)Session["UserName"];
            Model.IDPatient = u.IDPatient;
            if(ModelState.IsValid)
            {

                db.Feedback.Add(Model);
                db.SaveChanges();
            }
            //Model.Patient = u;
          
           
            return View(Model);
        }
        public ActionResult ViewFeedback()
        {
            var list = from fb in db.Feedback select fb;
            return View(list);
        }
        public ActionResult CurrentPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult ForgotPassword(string username, string email)
        {
            // Kiểm tra xem username có tồn tại và đúng hay không
            bool isUsernameExistAndCorrect = db.Patient.Any(u => u.UserName == username);

            // Kiểm tra xem email có tồn tại và đúng hay không
            bool isEmailExistAndCorrect = db.Patient.Any(u => u.Email == username);


            if (isUsernameExistAndCorrect)
            {
               
                return RedirectToAction("Error");
            }
            else if (isEmailExistAndCorrect)
            {
                // Gửi email đặt lại mật khẩu hoặc thực hiện các bước khác để xác nhận
                // Chuyển hướng đến trang xác nhận hoặc thông báo thành công
                return RedirectToAction("Error");
            }
            else
            {
               
                ModelState.AddModelError(string.Empty,"Invalid username or email.");
                return View();
            }
        }
    }
}