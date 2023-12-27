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
        public ActionResult ForgotPassword(Patient model)/// em khai bao co 2 tham so nhung khi goi ko co nen 
        {// ko vao action nay
         // Kiểm tra xem username có tồn tại và đúng hay không
            var patient = db.Patient.FirstOrDefault(u => u.UserName == model.Email && u.Email == model.Email);

            if (patient == null)
            {
                ViewBag["ThongBao"] = "Username và email không tồn tại"; // Hien thi viewbag ngoai view
                return View();
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
            else
            {
               
                ModelState.AddModelError(string.Empty,"Invalid username or email.");
                return View();
            }
        }
    }
}