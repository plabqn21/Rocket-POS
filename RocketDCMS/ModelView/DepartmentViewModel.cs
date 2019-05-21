using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class DepartmentViewModel: Department
    {
      public  List<Department> Departments { get; set; }
    }
}