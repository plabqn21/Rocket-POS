using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class Order
    {

        [Key]
        public Guid Id { get; set; }        
        public long? OrderCode { get; set; }

        public DateTime? OrderDate { get; set; }

        [ForeignKey("Patient")]
        public Guid? PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public Guid? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Test")]
        public Guid? TestId { get; set; }
        public Test Test { get; set; }

       
        public int? TestCode { get; set; }
        public Guid Branch_Id { get; set; }

    }
}