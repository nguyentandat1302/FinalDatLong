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
using System.Net.Mail;
using System.Net;

namespace FinalDatLong.Areas.Admin.Controllers
{
    public class AcceptBookingController : Controller
    {
        // GET: Admin/Booking
        Model1 db = new Model1();
        public ActionResult Index(int ? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.Booking.ToList().OrderBy(n => n.IDBooking).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Booking model)
        {

            if (ModelState.IsValid)
            {
                db.Booking.AddOrUpdate(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Accept(int id)
        {
            var booking = db.Booking.FirstOrDefault(n => n.IDBooking == id);

            if (booking != null)
            {
                booking.Accept = true;
                db.SaveChanges();

               SendBookingConfirmationEmail(booking.Patient.Email, true);

            }
            else
            {
                ViewBag.Error = "Error";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Refuse(int id)
        {
            var booking = db.Booking.FirstOrDefault(n => n.IDBooking == id);

            if (booking != null)
            {
                booking.Accept = false;
                db.SaveChanges();

               SendBookingConfirmationEmail(booking.Patient.Email, false);

            }
            else
            {
                ViewBag.Error = "Error";
            }

            return RedirectToAction("Index");
        }

        private void SendBookingConfirmationEmail(string patientEmail, bool accepted)
        {
            var subject = accepted ? "Booking Confirmation" : "Booking Refusal";
            var body = accepted ? "Your appointment has been successfully booked." : "Unfortunately, your appointment has been refused due to an emergency.";

            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("21280103e0017@student.tdmu.edu.vn", "sihi ngnu oipz plao"),
                EnableSsl = true,
            };

            var message = new MailMessage();
            message.From = new MailAddress("21280103e0017@student.tdmu.edu.vn");
            message.ReplyToList.Add("21280103e0017@student.tdmu.edu.vn");
            message.To.Add(new MailAddress(patientEmail));
            message.Subject = subject;
            message.Body = body;

            mail.Send(message);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Booking model = db.Booking.FirstOrDefault(n => n.IDBooking == id);
            model.Doctor = db.Doctor.FirstOrDefault(n => n.IDDoctor == model.IDDoctor);
            model.Patient = db.Patient.FirstOrDefault(n => n.IDPatient == model.IDPatient);
            return View(model);
        }
        [HttpPost]
        public ActionResult Detail(Booking model)
        {
            if (ModelState.IsValid)
            {
                db.Booking.AddOrUpdate(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}