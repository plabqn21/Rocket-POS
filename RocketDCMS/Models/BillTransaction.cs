using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class BillTransaction
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? Doctor_Id { get; set; }
        public Guid? Patient_Id { get; set; }
        [Required]
        public long? OrderNumber { get; set; }

        public Guid? Branch_Id { get; set; }

       

        public DateTime? BillDate { get; set; }
        [MaxLength(20)]
        public String Transtype { get; set; }


        public decimal? BillAmount { get; set; }


    }
}