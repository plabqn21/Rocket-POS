using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class ReportViewModelDC
    {   [Key]
        public Guid? Id { get; set; }
        public Guid? Patient_Id { get; set; }
        public long? OrderNumber { get; set; }
        public Guid? Branch_Id { get; set; }
        public string ReportName { get; set; }
        public DateTime? ReportStartDate { get; set; }
        public DateTime? ReportEndDate { get; set; }
    }
}