using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Promed.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {

            ViewBag.OpeningHours = _context.OpeningHours.OrderBy(o => o.OrderBy).ToList();

            return View();
        }

        public JsonResult Message(string name, string email, string tel, string message)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(tel))
            {
                Response.StatusCode = 406;
                return Json("Name,Email,Phone and Message is required", JsonRequestBehavior.AllowGet);
            }

            string body = "<ul><li>Name : {0}</li><li>Email : {1}</li><li>Phone : {2}</li></ul><p>{3}</p>";
            var MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress("h.orkhan1907@gmail.com"));  // replace with valid value 
            MailMessage.From = new MailAddress(email);  // replace with valid value
            MailMessage.Subject = "Your email subject";
            MailMessage.Body = string.Format(body, name, email, tel, message);
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