using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class Unit
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name ="Name")]
        public string UnitName { get; set; }
        [Display(Name ="Code")]
        public int? UnitCode { get; set; }

        [MaxLength(100)]
        public string Remarks { get; set; }
    }
}