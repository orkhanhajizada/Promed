using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promed.Models
{
    public class AboutElement
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required, StringLength(500)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [Required]
        [StringLength(200)]
        public string Icon { get; set; }


        public bool IsTop { get; set; }

    }
}