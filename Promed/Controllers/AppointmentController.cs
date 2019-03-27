using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Promed.Controllers
{
    public class AppointmentController : BaseController
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }
    }
}