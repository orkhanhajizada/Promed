using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Promed.Models
{
    public class Subslider
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required, StringLength(250)]
        [Column(TypeName =("ntext"))]
        public string Text { get; set; }
    }
}