using FinalDatLong.Models;
using Microsoft.Ajax.Utilities;
using SachOnline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Areas.Admin.Controllers
{
    public class TreatmentController : Controller
    {
        Model1 db = new Model1(); 
        // GET: Admin/Treatment
        public ActionResult Index()
        {
            var listTreatment = from treatment in db.Treatment select treatment;

            return View(listTreatment);
        }
       
       
        public ActionResult Detail(int id)
        {
            var patient = db.Treatment.FirstOrDefault(s => s.IDPatient == id);
            return View(patient);
        }
        //public ActionResult Add()
        //{
        //    //var lispa = from patient in db.Patient select patient;

        //    return View();
        //}
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Patient model, FormCollection f, HttpPostedFileBase fFileUpload)
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
        public ActionResult Edit(int id)
        {
            var patient = db.Treatment.FirstOrDefault(s => s.IDPatient == id);
            return View(patient);
        }
    }
}