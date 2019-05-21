using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class InvoiceUpdateViewModel
    {
        List<TestViewModelForInvoice> TestViewModelForInvoice { get; set; }
        public  List<Order> Orders { get; set; }

        public InvoiceViewModel InvoiceViewModel { get; set; }
        public long? OrderNumber { get; set; }


    }
}