using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class ReferelLab
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ReferelLabName { get; set; }
      
        public int? ReferelLabCode { get; set; }
        public string Contact { get; set; }

        
    }
}