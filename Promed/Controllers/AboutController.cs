using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Promed.ViewModels;  

namespace Promed.Controllers
{
    public class AboutController : BaseController
    {
       

        public ActionResult Index()
        {
            VwAbout model = new VwAbout
            {
                About = _context.Abouts.FirstOrDefault(),
                AboutElements = _context.AboutElements.OrderByDescending(a => a.Id).ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Facts = _context.Facts.OrderBy(f=>f.OrderBy).ToList(),
                Doctors = _context.Doctors.Include("Speciality").OrderByDescending(d=>d.Name).ToList(),
                Feedbacks = _context.Feedbacks.OrderByDescending(d => d.Date).Take(6).ToList()
            };


            return View(model);
        }
    }
}