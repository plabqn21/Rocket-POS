using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class PatientViewModel:Patient
    {
        public List<Patient> Patients { get; set; }
    }
}