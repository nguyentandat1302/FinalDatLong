using FinalDatLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;



namespace FinalDatLong.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Doctor
        public ActionResult Index(int ? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 10;
            return View(db.Doctor.ToList().OrderBy(n => n.IDDoctor).ToPagedList(iPageNum,iPageSize));
        }
    }
}