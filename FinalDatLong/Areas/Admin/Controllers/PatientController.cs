using FinalDatLong.Models;
using PagedList;
using System;
using System.Collections.Generic;
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
            int iPageSize = 7;
            return View(db.Patient.ToList().OrderBy(n => n.IDPatient).ToPagedList(iPageNum, iPageSize));
        }
    }
}