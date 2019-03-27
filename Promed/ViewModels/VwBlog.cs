 using Promed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Promed.ViewModels
{
    public class VwBlog
    {
        public List<Blog> Blogs { get; set; }

        public List<Category> Categories { get; set; }

        public int TotalPage { get; set; }

        public int Page { get; set; }

        public Setting Setting { get; set; }

        public List<Blog> LastPosts { get; set; }

        public int? Category { get; set; }
    }

    public class VwBlogRead {

        public Blog Blog { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<Category> Categories { get; set; }

        public Setting Setting { get; set; }

        public List<Blog> LastPosts { get; set; }
    }


}