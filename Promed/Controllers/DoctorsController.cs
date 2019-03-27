using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Promed.Controllers
{
    public class DoctorsController : BaseController
    {

        public ActionResult Index()
        {

            return View(_context.Doctors.Include("Speciality").ToList());
        }

        public ActionResult Details(string Slug)
        {
            if (string.IsNullOrEmpty(Slug))
            {
                return HttpNotFound();
            }

            var doctors = _context.Doctors.FirstOrDefault(d => d.Slug == Slug);

            if (doctors == null)
            {
                return HttpNotFound();
            }

            ViewBag.Doctor = _context.Doctors.Include("Department").Include("Speciality").ToList();


            return View(doctors);
        }
    }
}