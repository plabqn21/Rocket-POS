using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RamsoftBD.Models;

namespace RamsoftBD.ModelView
{
    public class DuePaymentViewModel
    {
        public BillTransaction BillTransaction { get; set; }
        public Patient Patient { get; set; }
        public InvoiceCheckout InvoiceCheckout { get; set; }
        public List<PaymentTransaction> PaymentTransactions { get; set; }

        public decimal? PaymentTransactionSum { get; set; }
        public decimal? TotalDue { get; set; }

        public decimal? TransAmount { get; set; }

        public Doctor Doctor { get; set; }

    }
}