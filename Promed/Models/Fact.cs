﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Promed.Models
{
    public class Fact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Icon { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [Required]
        public int OrderBy { get; set; }

    }
    }