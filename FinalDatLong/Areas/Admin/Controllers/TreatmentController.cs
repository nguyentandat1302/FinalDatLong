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
        public ActionResult Add(Treatment model)
        {
            var d = (Doctor)Session["Doctor"];
            model.IDDoctor = d.IDDoctor;
            if (ModelState.IsValid)
            {

                db.Treatment.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index","Treatment", new {Area = "Admin"});
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var patient = db.Treatment.FirstOrDefault(s => s.IDPatient == id);
            return View(patient);
        }
    }
}