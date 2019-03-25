using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promed.Models
{
    public class Slider
    {
        
        public int Id { get; set; }

        [Required,StringLength(300)]
        [Column(TypeName =("ntext"))]
        public string Text { get; set; }

        public string Photo { get; set; }
    }
}