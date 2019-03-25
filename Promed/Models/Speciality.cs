using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Promed.Models
{
    public class Speciality
    {
        public int Id { get; set; }


        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public List<Doctor> Doctors { get; set; }

    }
}