using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class InvoiceViewModel
    {
     
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public List<Test> Tests { get; set; }
    }
}