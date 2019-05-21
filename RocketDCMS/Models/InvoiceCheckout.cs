using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RamsoftBD.Models
{
    public class InvoiceCheckout
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? Doctor_Id { get; set; }
        public Guid? Patient_Id { get; set; }
        public long? OrderNumber { get; set; }

        public Guid? Branch_Id { get; set; }

        public Guid? Bill_Generator { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public string PaymentMode { get; set; }

        public string PaymentMethod { get; set; }

        public decimal TotalBill { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal Discount { get; set; }

        public DateTime? SampleReceiveDate { get; set; }
        public String SampleReceiveTime { get; set; }

        public String IsCorporateCustomer { get; set; }

        [ForeignKey("ReferelLab")]
        public Guid? ReferelLabId { get; set; }
        public ReferelLab ReferelLab { get; set; }

        public String Remarks { get; set; }

        public DateTime? ReportDeliveryDate { get; set; }

        public String ReportDeliveryTime { get; set; }


    }
}