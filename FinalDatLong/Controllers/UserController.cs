using FinalDatLong.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
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

        [HttpGet]
        public ActionResult CurrentPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CurrentPassword(FormCollection f)
        {
            string tempPass = f["password"];

            if (!string.IsNullOrWhiteSpace(tempPass))
            {
                string username = (string)TempData["Username"];
                string email = (string)TempData["Email"];

                Patient user = db.Patient.SingleOrDefault(u => u.UserName == username && u.Email == email);
                if (user != null)
                {
                    user.Password = tempPass;
                    user.MatKhauNL = tempPass;

                    db.SaveChanges();

                    return RedirectToAction("DangNhap");
                }
                else
                {
                    ViewBag.Error = "User not found.";
                    return View("Error"); // or another appropriate action
                }
            }
            else
            {
                ViewBag.Error = "Password cannot be null or empty.";
                return View("Error"); // or another appropriate action
            }
        }






        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult ForgotPassword(FormCollection f)
        {
            string username = f["Username"];
            string email = f["Email"];
            var patient = db.Patient.FirstOrDefault(u => u.UserName == username && u.Email == email);

            if (patient != null)
            {
                // Username and email match a record in the database, redirect to VerifyMail view
                return RedirectToAction("VerifyMail" , "User", new { email = patient.Email }); 
                
            }
            else
            {
                // Username and email do not match any record in the database
                ViewBag.ThongBao = "Username và email không tồn tại";
                return View();
            }
        }
        [HttpGet]
        public ActionResult VerifyMail(string email)
        {
         

            Random random = new Random();
            string otp = new string(Enumerable.Range(0, 6).Select(x => "0123456789"[random.Next(0, 10)]).ToArray());
            TempData["OTP"] = otp;

            var mail = new SmtpClient("smtp.gmail.com", 25)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("21280103e0017@student.tdmu.edu.vn", "sihi ngnu oipz plao"),
                EnableSsl = true,
            };
            var m = new MailMessage();
            m.From = new MailAddress("21280103e0017@student.tdmu.edu.vn");
            m.ReplyToList.Add("21280103e0017@student.tdmu.edu.vn");
            m.To.Add(new MailAddress(email));
            m.Subject = "Verify code has been sent!";
            m.Body = "Please enter the following code to verify that you are the one who changed the password: "  + otp;
            mail.Send(m);
            ViewBag.Email = "An email sent to your email address, please check the mailbox!";
            return View();
        }

        [HttpPost]
        public ActionResult VerifyMail(FormCollection a)
        {
            string userOtp = a["verifyCode"]; // Update to match the input field name in your form

            if (userOtp != null && userOtp == TempData["OTP"] as string)
            {
                return RedirectToAction("CurrentPassword", "User", new { otp = userOtp });
            }
            else
            {
                ViewBag.Error = "Your OTP is incorrect!";
                return View();
            }
        }





        // Thay co viec nhe va phan em lam theo cac buoc
        //Trong CSDL bang Paiteint them truong token
        //Dung Guid de phat sinh chuoi token
        // len mang tim hieu ham Guid => token
        //Update token cho use nay moi ma sinh
        //Gửi mail voi 2 tham so id = id cua user va token = moi sinh (Học lý thuyết da hướng dẫn rồi)
        // Với noi dung link reset: http:\.....\resetPass?id=?&&token=?...
        //Tạo moi con trolser moi resetpass => voi view resetpast chi gom 2 trường pass va passconfrim
        //Con troler nay kiem tra id va token hop le thi moi cho nhap pass moi va cap nhat vao csdl
        //Em tham kkhao tre n mang nhe

        //if (isUsernameExistAndCorrect)
        //{

        //    return RedirectToAction("Error");
        //}
        //else if (isEmailExistAndCorrect)
        //{
        //    // Gửi email đặt lại mật khẩu hoặc thực hiện các bước khác để xác nhận
        //    // Chuyển hướng đến trang xác nhận hoặc thông báo thành công
        //    return RedirectToAction("Error");
        //}
    }
}