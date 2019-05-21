using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RamsoftBD.ModelView;
using RamsoftBD.Models;

namespace RamsoftBD.Controllers
{
    public class ReportControllerDC : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

     

      
        public ActionResult ParameterEntryDC()
        {
            return View();
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
