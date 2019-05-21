using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RamsoftBD.Models;
using RamsoftBD.ModelView;

namespace RamsoftBD.ModelView
{
    public class UnitViewModel:Unit
    {
        public List<Unit> Units { get; set; }
    }
}