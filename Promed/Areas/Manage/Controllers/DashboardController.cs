using Promed.Areas.Manage.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Promed.Areas.Manage.Controllers
{

    [Auth]
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}