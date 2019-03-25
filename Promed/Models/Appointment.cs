using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promed.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int DoctorId{ get; set; }

        public Doctor Doctor { get; set; }
        public Department Department { get; set; }
    }
}