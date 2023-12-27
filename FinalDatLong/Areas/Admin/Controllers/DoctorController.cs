using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data.Entity.Migrations;
using System.Drawing;
using SachOnline;

namespace FinalDatLong.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Doctor
        public ActionResult Index(int ? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.Doctor.ToList().OrderBy(n => n.IDDoctor).ToPagedList(iPageNum,iPageSize));
        }


        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Doctor model, FormCollection f, HttpPostedFileBase fFileUpload)
        {

            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    Image img = Image.FromStream(fFileUpload.InputStream, true, true);
                    model.Avatar = Utility.ConvertImageToBase64(img);
                }

                db.Doctor.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public static string ConverImageToBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public ActionResult Details(int id)
        {
            var doctor = db.Doctor.SingleOrDefault(n => n.IDDoctor == id);
            if (doctor == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(doctor);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var doctor = db.Doctor.SingleOrDefault(n => n.IDDoctor== id);
            if (doctor == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            var doctor = db.Doctor.SingleOrDefault(n => n.IDDoctor == id);
            if (doctor == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           // var ctdh = db.Doctor.Where(ct => ct.IDDoctor == id);
           // if (ctdh.Count() > 0)
           // {
           //ViewBag.ThongBao = "Sách này đang có trong bảng Chi tiết đặt hàng <br>" +
           //         "Nếu muốn xóa thì phải xóa hết mã sách này trong chi tiết đặt hàng";
           //     return View(doctor);     
           // }
            var dt = db.Treatment.Where(t => t.IDDoctor == id).ToList();
            if(dt.Count>0)
            {
                ViewBag.ThongBao = "BS da dieu tri ko duoc phep xoa";
                return RedirectToAction("Delete", "Doctor",new {id = doctor.IDDoctor });

            }

            db.Doctor.Remove(doctor);
            db.SaveChanges();
           
            

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Doctor doctor = db.Doctor.SingleOrDefault(n => n.IDDoctor == id);
            if (doctor == null)
            {
                Response.StatusCode = 404;
                return null;
            }
         
            return View(doctor);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, HttpPostedFileBase fFileUpload)
        {
            Doctor doctor = db.Doctor.SingleOrDefault(n => n.IDDoctor == id);

            if (ModelState.IsValid)
            {
                
                db.Doctor.AddOrUpdate(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

       
     

    }
}