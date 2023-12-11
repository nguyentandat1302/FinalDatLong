using FinalDatLong.Models;
using SachOnline;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.UI.WebControls;

namespace FinalDatLong.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        Model1 db = new Model1();
        //public ActionResult Error()
        //{
        //    // Logic xử lý khi có lỗi
        //    return View();
        //}
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Navbar()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult LayoutNavbar()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return PartialView();
        }
        public ActionResult NavbarDangNhap()
        {
            return PartialView();
        }
        public ActionResult SlideShow()
        {
            return PartialView();
        }
        public ActionResult Video()
        {
            return PartialView();
        }
        public ActionResult Card()
        {
            return PartialView();
        }
        public ActionResult NewBooking()
        {
            return PartialView();
        }
        //public ActionResult ProfileDoctor(int IDDoctor)
        //{
        //    var doctor = db.Doctor.FirstOrDefault(s => s.IDDoctor == IDDoctor);
        //    return View(doctor);
        //}

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
        public ActionResult PatientProfile()
        {

            if (Session["UserName"] != null)
            {
                var patient = (Patient)Session["UserName"];
                // Lấy thông tin hồ sơ từ cơ sở dữ liệu dựa trên IDPatient
                //var existingPatient = db.Patient.Find(patient.IDPatient);
                patient.MatKhauNL = patient.Password;

                if (patient != null)
                {
                    return View(patient);
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PatientProfile(Patient model, HttpPostedFileBase myFile)
        {
           

            if (ModelState.IsValid)
            {


                if (myFile != null)
                {
                    Image img = Image.FromStream(myFile.InputStream, true, true);
                    model.Avatar = Utility.ConvertImageToBase64(img);
                }
               
                db.Patient.AddOrUpdate(model);
                db.SaveChanges();
                Session["UserName"] = model;
                //return View(model);
            }
            
            
            return View(model);
        }


        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Edit(FormCollection f, HttpPostedFileBase fFileUpload)
        //{
        //    var patient = db.Patient.SingleOrDefault(n => n.IDPatient == int.Parse(f[""]));

        //    if (ModelState.IsValid)
        //    {
        //        if (fFileUpload != null)
        //        {

        //            var sFileName = Path.GetFileName(fFileUpload.FileName);

        //            var path = Path.Combine(Server.MapPath("~/Images"), sFileName);
        //            //Kiểm tra file đã tồn tại chưa
        //            if (!System.IO.File.Exists(path))
        //            {
        //                fFileUpload.SaveAs(path);
        //            }
        //            patient.Avatar = sFileName;
        //        }
             
        //        return RedirectToAction("Index");
        //    }
        //    return View(patient);
        //}



    }
}