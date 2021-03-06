﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promed.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required, MinLength(250)]
        [Column(TypeName ="ntext")]
        public string Text { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }
    }
}