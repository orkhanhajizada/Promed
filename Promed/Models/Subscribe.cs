using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Promed.Models
{
    public class Subscribe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }
    }
}