using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promed.Models
{
    public class Department
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Slug { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Adress { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [StringLength(200)]
        public string Icon { get; set; }

        [Required]
        [StringLength(350)]
        public string Title { get; set; }

        [Required, MinLength(250)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [Required, MaxLength(250)]
        [Column(TypeName = "ntext")]
        public string MinAbout { get; set; }

        public List<Doctor> Doctors { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}