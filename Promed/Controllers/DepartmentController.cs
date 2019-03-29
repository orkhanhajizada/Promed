using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Promed.Controllers
{
    public class DepartmentController : BaseController
    {
        
        public ActionResult Details(string Slug)
        {
            if (string.IsNullOrEmpty(Slug))
            {
                return HttpNotFound();
            }

            var departments = _context.Departments.FirstOrDefault(d => d.Slug == Slug);

            if (departments == null)
            {
                return HttpNotFound();
            }

            ViewBag.Doctor = _context.Doctors.Include("Department").FirstOrDefault(h=>h.DepartmentId == departments.Id && h.IsHead==true);


            ViewBag.Depatment = _context.Departments.FirstOrDefault();


            ViewBag.Setting = _context.Settings.FirstOrDefault();


            return View(departments);

            
        }
    }
}