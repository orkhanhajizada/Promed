using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Promed.ViewModels;

namespace Promed.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            VwHome model = new VwHome();

            model.Sliders = _context.Sliders.ToList();

            model.Subsliders = _context.Subsliders.OrderByDescending(s=>s.Id).Take(3).ToList();

            model.About = _context.Abouts.FirstOrDefault();

            model.Departments = _context.Departments.OrderByDescending(d => d.Name).ToList();

            model.Facts = _context.Facts.OrderBy(f => f.OrderBy).ToList();

            model.Doctors = _context.Doctors.Include("Speciality").OrderByDescending(d => d.Name).ToList();

            model.Feedbacks = _context.Feedbacks.OrderByDescending(d => d.Date).Take(6).ToList();

            model.Blogs = _context.Blogs.Include("Doctor").OrderByDescending(b => b.Date).Take(6).ToList();


            return View(model);
        }
    }
}