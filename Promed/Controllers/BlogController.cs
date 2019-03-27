using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Promed.Models;
using Promed.ViewModels;

namespace Promed.Controllers
{
    public class BlogController : BaseController
    {
  
        public ActionResult Index(int? category,int page = 1 )
        {
            VwBlog model = new VwBlog();

            model.Blogs = _context.Blogs.Include("Category").Include("Doctor").Where(c => (category != null ? c.CategoryId == category : true)).OrderByDescending(b => b.Date).Skip((page-1)*4).Take(4).ToList();

            model.TotalPage =Convert.ToInt32(Math.Ceiling(_context.Blogs.Count() / 4.00));

            model.Categories = _context.Categories.ToList();

            model.Setting = _context.Settings.FirstOrDefault();

            model.LastPosts = _context.Blogs.Include("Category").Include("Doctor").OrderByDescending(b => b.Date).Take(6).ToList();


            if (page<1 || page > model.TotalPage)
            {
                return HttpNotFound();
            }

            model.Page = page;

            return View(model);
        }

        public ActionResult Read(string Slug)
        {
            VwBlogRead model = new VwBlogRead();

            model.Blog = _context.Blogs.Include("Category").Include("Doctor").FirstOrDefault(s => s.Slug == Slug);

            model.Categories = _context.Categories.ToList();

            model.Setting = _context.Settings.FirstOrDefault();

            model.LastPosts = _context.Blogs.Include("Category").Include("Doctor").OrderByDescending(b => b.Date).Take(6).ToList();

            model.Blogs = _context.Blogs.Include("Category").Include("Doctor").OrderByDescending(b => b.Date).ToList();

            if (string.IsNullOrEmpty(Slug))
            {
                return HttpNotFound();
            }

            
            if (model == null)
            {
                return HttpNotFound();
            }


            return View(model);

        }
    }
}