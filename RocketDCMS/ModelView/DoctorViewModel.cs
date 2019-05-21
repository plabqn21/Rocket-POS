using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class DoctorViewModel : Doctor
    {   
        public List<Doctor> Doctors { get; set; }

       
    }
}