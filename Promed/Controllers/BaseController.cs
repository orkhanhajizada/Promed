using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Promed.DAL;
using Promed.Models;

namespace Promed.Controllers
{
    public class BaseController : Controller
    {

        protected readonly PromedContext _context = new PromedContext();

        public BaseController()
        {
            ViewBag.Setting = _context.Settings.FirstOrDefault();
        }
    }
}