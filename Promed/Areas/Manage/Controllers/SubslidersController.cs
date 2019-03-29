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
    public class SubslidersController : Controller
    {
        private PromedContext db = new PromedContext();

        // GET: Manage/Subsliders
        public ActionResult Index()
        {
            return View(db.Subsliders.ToList());
        }

        // GET: Manage/Subsliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subslider subslider = db.Subsliders.Find(id);
            if (subslider == null)
            {
                return HttpNotFound();
            }
            return View(subslider);
        }

        // GET: Manage/Subsliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Subsliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo,Title,Text")] Subslider subslider , HttpPostedFileBase Photo)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Please Select file");
            }
            else
            {
                subslider.Photo = FileManager.Upload(Photo);
            }


            if (ModelState.IsValid)
            {
                db.Subsliders.Add(subslider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subslider);
        }

        // GET: Manage/Subsliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subslider subslider = db.Subsliders.Find(id);
            if (subslider == null)
            {
                return HttpNotFound();
            }
            return View(subslider);
        }

        // POST: Manage/Subsliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,Title,Text")] Subslider subslider, HttpPostedFileBase Photo)
        {
            db.Entry(subslider).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(subslider).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                FileManager.Delete(subslider.Photo);

                subslider.Photo = FileManager.Upload(Photo);
            }


            if (ModelState.IsValid)
            {
                db.Entry(subslider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subslider);
        }

        // GET: Manage/Subsliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subslider subslider = db.Subsliders.Find(id);
            if (subslider == null)
            {
                return HttpNotFound();
            }
            return View(subslider);
        }

        // POST: Manage/Subsliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subslider subslider = db.Subsliders.Find(id);
            db.Subsliders.Remove(subslider);
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
