using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class Department
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }
        public int? DepartmentCode { get; set; }
        public String Contact { get; set; }
        public string Remarks { get; set; }

       
    }
}