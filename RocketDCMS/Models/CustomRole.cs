using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class CustomRole
    {
        [Key]
        [MaxLength(128)]
        public string Id { get; set; }

        [MaxLength(256)]
        [Required]
        [Display(Name ="Role Name")]
        public string Name { get; set; }
    }
}