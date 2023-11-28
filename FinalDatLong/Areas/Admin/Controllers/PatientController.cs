using FinalDatLong.Models;
using PagedList;
using SachOnline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinalDatLong.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        // GET: Admin/Patient
        Model1 db = new Model1();
        // GET: Admin/Doctor
        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 5;
            return View(db.Patient.ToList().OrderBy(n => n.IDPatient).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Patient model, FormCollection f, HttpPostedFileBase fFileUpload)
        {

            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    Image img = Image.FromStream(fFileUpload.InputStream, true, true);
                    model.Avatar = Utility.ConvertImageToBase64(img);
                }

                db.Patient.Add(model);
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
            var patient = db.Patient.SingleOrDefault(n => n.IDPatient == id);
            if (patient == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(patient);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var patient = db.Patient.SingleOrDefault(n => n.IDPatient == id);
            if (patient == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(patient);
        }
        public ActionResult Delete(int id, FormCollection f)
        {
            var patient = db.Patient.SingleOrDefault(n => n.IDPatient == id);
            if (patient == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           

            db.Patient.Remove(patient);
            db.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}


        