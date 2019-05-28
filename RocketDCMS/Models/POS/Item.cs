using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models.POS
{
    public class Item
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

        [ForeignKey("ItemSubCatagory")]
        public Guid? ItemSubCatagoryId { get; set; }
        public ItemSubCatagory ItemSubCatagory { get; set; }

        [ForeignKey("ItemUnit")]
        [Display(Name = "ItemUnit")]
        public Guid? ItemUnitId { get; set; }
        public ItemUnit ItemUnit { get; set; }

        [ForeignKey("Supplier")]
        public Guid? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Discount(%)")]
        public decimal? Discount { get; set; }

        [ForeignKey("Branch")]
        public Guid? BranchId { get; set; }
        public RamsoftBD.Models.Branch Branch { get; set; }

    }
}