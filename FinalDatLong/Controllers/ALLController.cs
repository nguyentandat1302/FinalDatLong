using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDatLong.Controllers
{
    public class ALLController : Controller
    {
        // GET: ALL
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contacts() 
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Question()
        {
            return View();
        }
        public ActionResult Service()
        {
            return PartialView();
        }
        public ActionResult Instruction()
        {
            return PartialView();
        }
    }
}