using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home

        Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string UserName = f["UserName"];
            string Password = f["Password"];
            var admin = db.Patient.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            if (admin != null)
            {
                Session["Admin"] = admin;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Sai UserName va Password";
            }
            return View();
        }
    }
}
