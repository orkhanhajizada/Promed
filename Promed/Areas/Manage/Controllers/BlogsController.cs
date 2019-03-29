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
    public class BlogsController : Controller
    {
        private PromedContext db = new PromedContext();

        // GET: Manage/Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category).Include(b => b.Doctor);
            return View(blogs.OrderByDescending(b=>b.Date).ToList());
        }

        // GET: Manage/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Manage/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name");
            return View();
        }

        // POST: Manage/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Slug,Title,Text,MinAbout,Photo,TitlePhoto,Date,CategoryId,DoctorId")] Blog blog, HttpPostedFileBase Photo, HttpPostedFileBase TitlePhoto)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Please Select file");
            }
            if (TitlePhoto == null)
            {
                ModelState.AddModelError("Title Photo", "Please Select file");
            }
            else
            {
                blog.Photo = FileManager.Upload(Photo);
                blog.TitlePhoto = FileManager.Upload(TitlePhoto);
            }

            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", blog.DoctorId);
            return View(blog);
        }

        // GET: Manage/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", blog.DoctorId);
            return View(blog);
        }

        // POST: Manage/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Slug,Title,Text,MinAbout,Photo,TitlePhoto,Date,CategoryId,DoctorId")] Blog blog, HttpPostedFileBase Photo, HttpPostedFileBase TitlePhoto)
        {
            db.Entry(blog).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(blog).Property(a => a.Photo).IsModified = false;
            }
            if (TitlePhoto == null)
            {
                db.Entry(blog).Property(b => b.TitlePhoto).IsModified = false;
            }
            else
            {
                FileManager.Delete(blog.Photo);
                FileManager.Delete(blog.TitlePhoto);

                blog.Photo = FileManager.Upload(Photo);
                blog.TitlePhoto = FileManager.Upload(TitlePhoto);
            }

            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", blog.DoctorId);
            return View(blog);
        }

        // GET: Manage/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Manage/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
