using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Promed.Models;

namespace Promed.ViewModels
{
    public class VwHome
    {
        public List<Slider> Sliders { get; set; }

        public List<Subslider> Subsliders { get; set; }

        public About About { get; set; }

        public List<Department> Departments { get; set; }

        public List<Fact> Facts { get; set; }

        public List<Doctor> Doctors { get; set; }

        public List<Feedback> Feedbacks { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}