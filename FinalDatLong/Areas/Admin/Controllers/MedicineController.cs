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
    public class MedicineController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Medicine
        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.Medicine.ToList().OrderBy(n => n.IDMedicine).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Medicine model)
        {

            var m = db.Medicine.FirstOrDefault(k => k.IDMedicine == model.IDMedicine);
            if (ModelState.IsValid)
            {
                db.Medicine.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var m = db.Medicine.SingleOrDefault(n => n.IDMedicine == id);
            if (m == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(m);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(int id, FormCollection f)
        {
            var m = db.Medicine.SingleOrDefault(n => n.IDMedicine == id);
            if (m == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.Medicine.Remove(m);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}