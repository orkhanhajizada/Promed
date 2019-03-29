using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Promed.DAL;
using Promed.Models;

namespace Promed.Areas.Manage.Controllers
{
    public class SpecialitiesController : Controller
    {
        private PromedContext db = new PromedContext();

        // GET: Manage/Specialities
        public ActionResult Index()
        {
            return View(db.Specialities.ToList());
        }

       

        // GET: Manage/Specialities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Specialities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                db.Specialities.Add(speciality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speciality);
        }

        // GET: Manage/Specialities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        // POST: Manage/Specialities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speciality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speciality);
        }

        // GET: Manage/Specialities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        // POST: Manage/Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Speciality speciality = db.Specialities.Find(id);
            db.Specialities.Remove(speciality);
            db.SaveChanges();
            return RedirectToAction("Index");
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
