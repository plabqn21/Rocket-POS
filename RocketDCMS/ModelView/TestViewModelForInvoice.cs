using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class TestViewModelForInvoice
    {
        [Key]
        public Guid? Test_Id { get; set; }
        [Display(Name = "Code")]
        public int? TestCode { get; set; }
        public decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        public Guid? Doctor_Id { get; set; }
        public Guid? Patient_Id { get; set; }
        public long? OrderNumber { get; set; }




    }
}