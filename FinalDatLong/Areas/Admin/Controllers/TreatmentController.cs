using FinalDatLong.Models;
using Microsoft.Ajax.Utilities;
using SachOnline;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
      
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Treatment model)
        {
            Doctor d = (Doctor)Session["Doctor"];
            model.IDDoctor = d.IDDoctor;
            
            var kh = db.Patient.FirstOrDefault(k => k.IDPatient == model.IDPatient);
            if (kh == null)
            {
                ModelState.AddModelError("IDPatient", "Khách hàng không tồn tại");
                return View();
            }
            if (ModelState.IsValid)
            {

                db.Treatment.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index","Treatment", new {Area = "Admin"});
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Treatment = db.Treatment.SingleOrDefault(n => n.IDTreatment == id);
            if (Treatment == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Treatment);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            var Treatment = db.Treatment.SingleOrDefault(n => n.IDTreatment == id);
            if (Treatment == null)
            {
                Response.StatusCode = 404;
                return null;
            }


            db.Treatment.Remove(Treatment);
            db.SaveChanges();



            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var patient = db.Treatment.FirstOrDefault(s => s.IDPatient == id);
            if (patient == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(patient);
        }
        [HttpPost]
        public ActionResult Edit(Treatment model)
        {
            if (ModelState.IsValid)
            {
                db.Treatment.AddOrUpdate(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}