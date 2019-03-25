using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Promed.Models;


namespace Promed.DAL
{
    public class PromedContext:DbContext
    {
        public PromedContext() : base("PromedContext")
        {
             
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Subslider> Subsliders { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<AboutElement> AboutElements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}