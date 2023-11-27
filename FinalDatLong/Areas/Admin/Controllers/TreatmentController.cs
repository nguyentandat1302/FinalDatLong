using FinalDatLong.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
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
    }
}