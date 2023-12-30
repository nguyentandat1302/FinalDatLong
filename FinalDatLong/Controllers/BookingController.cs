using FinalDatLong.Models;
using SachOnline;
using System;
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
        //public ActionResult ProfileDoctor(int id)
        //{
        //    var doctor = db.Doctor.FirstOrDefault(n => n.IDDoctor == id);
        //    return PartialView(doctor);
        //}

        // em new booking o day 
        //Dung get o tren em khai bao get r ma thay => 2 phuong thuc cung get phai khac nhau ve ten pt hoac tham so
        //get
        //public ActionResult ProfileDoctor2(int id ,FormCollection f)
        //{
        //    //Em khai bao id ma khi goi truyen vao IDDoctor nen se ko goi method nay
        //    Booking Booking = new Booking();
        //    var doctor = db.Doctor.Find(id);

        //    if (doctor == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    if (Session["UserName"] != null)
        //    {
        //        var patient = (Patient)Session["UserName"];
        //        // Lấy thông tin hồ sơ từ cơ sở dữ liệu dựa trên IDPatient

        //        if (patient != null)
        //        {
        //            Booking.Patient = patient;
        //            Booking.IDPatient = patient.IDPatient;
        //        }
        //        else
        //        {
        //            return RedirectToAction("Error");
        //        }
        //    }

        //    Booking.IDDoctor = id;
        //    Booking.Doctor = doctor;

        //    if (ModelState.IsValid)
        //    {
        //        db.Booking.Add(Booking);
        //        db.SaveChanges();
        //    }
        //    return View();
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