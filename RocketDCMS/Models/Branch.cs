using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class Branch
    {
        [Key]
        public Guid Id { get; set; }
       
      
        public int? BranchCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string BranchName { get; set; }
        public DateTime? OpeningDate { get; set; }

       
        public string Address { get; set; }

        public DateTime? CloseDate { get; set; }
        public string BranchStatus { get; set; }
    }
}