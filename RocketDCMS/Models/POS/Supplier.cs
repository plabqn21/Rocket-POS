using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketDCMS.Models.POS
{
    public class Supplier
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Code")]
        public int? Code { get; set; }


        [Required]
        [MaxLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [MaxLength(200)]
        public string Account { get; set; }


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
        public RamsoftBD.Models.Branch Branch { get; set; }


    }
}