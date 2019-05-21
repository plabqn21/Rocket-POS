using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class DoctorViewModelForInvoice
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string DoctorName { get; set; }




        public int? DoctorCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Qualification { get; set; }

        [Required]
        [MaxLength(100)]
        public string Hospital { get; set; }

        [Required]
        [MaxLength(15)]
        public string Type { get; set; }

        [Required]
        [MaxLength(200)]
        public string Remarks { get; set; }

        [ForeignKey("Branch")]
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }

        public double? CommissionRate { get; set; }

        public decimal NewPatientFee { get; set; }
        public decimal OldPatientFee { get; set; }

        public int? OldPatientFeeDuration { get; set; }

        public List<Doctor> Doctors { get; set; }

        public Guid? Patient_Id { get; set; }
    }
}