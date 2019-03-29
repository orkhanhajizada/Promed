using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promed.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Slug { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [Required, MaxLength(250)]
        [Column(TypeName = "ntext")]
        public string MinAbout { get; set; }

        [Required, MinLength(250)]
        [Column(TypeName = "ntext")]
        public string About { get; set; }

        [Required]
        [StringLength(250)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(300)]
        public string Adress { get; set; }

        [StringLength(250)]
        public string Facebook { get; set; }

        [StringLength(250)]
        public string Twitter { get; set; }

        [StringLength(250)]
        public string Google { get; set; }

        [StringLength(250)]
        public string Linkedin { get; set; }

        public bool IsHead { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        public Department Department { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}