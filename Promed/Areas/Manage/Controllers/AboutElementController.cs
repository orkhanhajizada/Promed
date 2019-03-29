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
    public class AboutElementController : Controller
    {
        private PromedContext db = new PromedContext();

        // GET: Manage/AboutElement
        public ActionResult Index()
        {
            return View(db.AboutElements.ToList());
        }

        // GET: Manage/AboutElement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutElement aboutElement = db.AboutElements.Find(id);
            if (aboutElement == null)
            {
                return HttpNotFound();
            }
            return View(aboutElement);
        }

        // GET: Manage/AboutElement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/AboutElement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Icon,IsTop")] AboutElement aboutElement)
        {
            if (ModelState.IsValid)
            {
                db.AboutElements.Add(aboutElement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutElement);
        }

        // GET: Manage/AboutElement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutElement aboutElement = db.AboutElements.Find(id);
            if (aboutElement == null)
            {
                return HttpNotFound();
            }
            return View(aboutElement);
        }

        // POST: Manage/AboutElement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Icon,IsTop")] AboutElement aboutElement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutElement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutElement);
        }

        // GET: Manage/AboutElement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutElement aboutElement = db.AboutElements.Find(id);
            if (aboutElement == null)
            {
                return HttpNotFound();
            }
            return View(aboutElement);
        }

        // POST: Manage/AboutElement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutElement aboutElement = db.AboutElements.Find(id);
            db.AboutElements.Remove(aboutElement);
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
