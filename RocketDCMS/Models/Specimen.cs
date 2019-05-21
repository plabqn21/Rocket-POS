using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class Specimen
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string SpecimenName { get; set; }
        [Display(Name = "Code")]
        public int? SpecimenCode { get; set; }
        
        public string Remarks { get; set; }

    }
}