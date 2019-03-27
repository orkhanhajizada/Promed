using Promed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Promed.Controllers
{
    public class AppointmentController : BaseController
    {


        public ActionResult Index()
        {

            ViewBag.Doctor = _context.Doctors.Include("Department").ToList();

            ViewBag.Department = _context.Departments.OrderByDescending(d=>d.Name).ToList();

            return View();
        }

        public JsonResult GetDoctor(int? DepartmentId)
        {

            Department department = _context.Departments.Find(DepartmentId);


            if (DepartmentId == null)
            {
                Response.StatusCode = 400;
                return Json(new
                {
                    message = "DepartmentId yoxdu"
                }, JsonRequestBehavior.AllowGet);

            }

            if (department == null)
            {
                Response.StatusCode = 404;
                return Json(new
                {
                    message = "department Tapilmadi"
                }, JsonRequestBehavior.AllowGet);
            }

            var doctors = _context.Doctors.Where(m => m.DepartmentId == department.Id).ToList();

            return Json(doctors.Select(m => new
            {
                m.Id,
                m.Name
            }), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Message(string name, string email, string tel, int DepartmenId, int DoctorId, DateTime date, string message)
        {

            Department department = _context.Departments.Find(DepartmenId);
            Doctor doctor = _context.Doctors.Find(DoctorId);
            

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(tel))
            {
                Response.StatusCode = 406;
                return Json("All inputs is required", JsonRequestBehavior.AllowGet);
            }

            string body = "<ul><li>Name : {0}</li><li>Email : {1}</li><li>Phone : {2}</li><li>Department : {3}</li><li>Doctor : {4}</li><li>Date : {5}</li></ul><p>{6}</p>";
            var MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress("h.orkhan1907@gmail.com"));  // replace with valid value 
            MailMessage.From = new MailAddress(email);  // replace with valid value
            MailMessage.Subject = "Your email subject";
            MailMessage.Body = string.Format(body, name, email, tel, department.Name, doctor.Name, date.ToString("dd.mm.yyyy"), message);
            MailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential
                {
                    UserName = "h.orkhan1907@gmail.com",  // replace with valid value
                    Password = "orxan12gfb"  // replace with valid value
                }
            };

            client.Send(MailMessage);


            return Json("Your message sent,thanks", JsonRequestBehavior.AllowGet);
        }

    }
}