using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class SpecimenViewModel: Specimen
    {
      public  List<Specimen> Specimens { get; set; }
    }
}