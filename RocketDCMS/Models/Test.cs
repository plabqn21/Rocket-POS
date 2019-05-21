using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class Test
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Name")]
        public string TestName { get; set; }
        [Display(Name = "Code")]
        public int? TestCode { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Discount(%)")]
        public decimal? Discount { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Specimen")]
        [Display(Name = "Specimen")]
        public Guid? SpecimenId { get; set; }
        public Specimen Specimen { get; set; }

      
        [MaxLength(100)]
        public string Remarks { get; set; }
        [Display(Name = "Reference Value(M)")]
        public decimal? ReferenceValueMale { get; set; }

        [Display(Name = "Reference Value(F)")]
        public decimal? ReferenceValueFeMale { get; set; }

        [Display(Name = "Reference Value(C)")]
        public decimal? ReferenceValueChildren { get; set; }

        [ForeignKey("Unit")]
        [Display(Name = "Unit")]
        public Guid? UnitId { get; set; }
        public Unit Unit { get; set; }


    }
}