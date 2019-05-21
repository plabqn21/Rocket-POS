using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class Patient
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Name")]
        public string PatientName { get; set; }
        [Display(Name = "Code")]
        public int? PatientCode { get; set; }
        [Required]
        [MaxLength(20)]
        public string Gender { get; set; }

        [Required]
   
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string AgeType { get; set; }

        [MaxLength(5)]
        public string BloodGroup { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(20)]
        [Display(Name = "Mobile")]
        public string MobileNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Remarks { get; set; }

        [ForeignKey("Branch")]
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }

      

    }
}