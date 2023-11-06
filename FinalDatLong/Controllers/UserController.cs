using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(UserLogin user)
        {
            //if (ModelState.IsValid)
            //{
            //    var u = db.KHACHHANG.FirstOrDefault(k => k.Taikhoan == user.Username && k.Matkhau == user.Password);
            //    if (u != null)
            //    {
            //        Session["TaiKhoan"] = u;
            //        ViewBag.ThongBao = "Đăng Nhập Thành Công";
            //        return Redirect("~/");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("Password", "Error");
            //    }
            //}
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Booking");
        }
    }
}