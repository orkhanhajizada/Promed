using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Promed.Areas.Manage.Helpers;
using Promed.DAL;
using Promed.Models;

namespace Promed.Areas.Manage.Controllers
{
    public class SettingsController : Controller
    {
        private PromedContext db = new PromedContext();

        // GET: Manage/Settings
        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

        // GET: Manage/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting about = db.Settings.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Manage/Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Photo,Phone,Phone2,Email,Email2,Adress,Facebook,Twitter,Google,Linkedin,VideoLink,VideoText,Lat,Lng")] Setting setting, HttpPostedFileBase Photo)
        {
            db.Entry(setting).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(setting).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                FileManager.Delete(setting.Photo);

                setting.Photo = FileManager.Upload(Photo);
            }


            if (ModelState.IsValid)
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
