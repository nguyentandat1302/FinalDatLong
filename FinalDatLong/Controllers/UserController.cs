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
        Model1 db = new Model1();
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
        public ActionResult DangKy(Partient Model)
        {
            if (ModelState.IsValid)
            {
                var kh = db.Partients.FirstOrDefault(k => k.UserName == Model.UserName);
                if (kh != null)
                {
                    ModelState.AddModelError("UserName", "Ten tai Khoan ton tai");
                    return View(Model);
                }

                db.Partients.Add(Model);
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
                var u = db.Partients.FirstOrDefault(k => k.UserName == user.Username && k.Password == user.Password);
                if (u != null)
                {
                    Session["UserName"] = u;
                    ViewBag.ThongBao = "Đăng Nhập Thành Công";
                    return Redirect("~/");
                }
                else
                {
                    ModelState.AddModelError("Password", "Error");
                }
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Booking");
        }
    }
}