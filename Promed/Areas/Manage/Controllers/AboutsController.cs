﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Promed.DAL;
using Promed.Models;
using Promed.Areas.Manage.Helpers;

namespace Promed.Areas.Manage.Controllers
{
    public class AboutsController : Controller
    {
        private PromedContext db = new PromedContext();

        // GET: Manage/Abouts
        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        

        // GET: Manage/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Manage/Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Photo")] About about,HttpPostedFileBase Photo)
        {

            db.Entry(about).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(about).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                FileManager.Delete(about.Photo);

                about.Photo = FileManager.Upload(Photo);
            }


            if (ModelState.IsValid)
            {
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
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
