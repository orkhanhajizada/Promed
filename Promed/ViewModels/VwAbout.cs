using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Promed.Models;

namespace Promed.ViewModels
{
    public class VwAbout
    {
        public About About { get; set; }

        public List<AboutElement> AboutElements { get; set; }

        public Setting Setting { get; set; }

        public List<Fact> Facts { get; set; }

        public List<Doctor> Doctors { get; set; }

        //public Speciality Speciality { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}