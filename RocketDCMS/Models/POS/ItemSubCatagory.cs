using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketDCMS.Models.POS
{
    public class ItemSubCatagory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Code")]
        public int? Code { get; set; }

        public string Details { get; set; }

        [ForeignKey("ItemCatagory")]
        public Guid? ItemCatagoryId { get; set; }
        public ItemCatagory ItemCatagory { get; set; }

        [ForeignKey("Branch")]
        public Guid? BranchId { get; set; }
        public RamsoftBD.Models.Branch Branch { get; set; }

    }
}