using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RamsoftBD.ModelView
{
    public class TestViewModel:Test
    {
        public List<Test> Tests { get; set; }
    }
}