using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RamsoftBD.Models;
using RamsoftBD.ModelView;

namespace RamsoftBD.Controllers
{
    [Authorize]
    public class ReferelLabsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

     

        // GET: ReferelLabs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferelLab referelLab = await db.ReferelLabs.FindAsync(id);
            if (referelLab == null)
            {
                return HttpNotFound();
            }
            return View(referelLab);
        }

        // GET: ReferelLabs/Create
        public ActionResult Create()
        {
            ReferelLabViewModel ReferelLabViewModel = new ReferelLabViewModel();
            ReferelLabViewModel.ReferelLabs = db.ReferelLabs.ToList();
            return View(ReferelLabViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReferelLab referelLab)
        {
            if (ModelState.IsValid)
            {
                referelLab.Id = Guid.NewGuid();
                var Counter = db.ReferelLabs.Max(x=>x.ReferelLabCode)+1;
                if (Counter == null)
                {
                    Counter = 1;

                }
                referelLab.ReferelLabCode = Counter;
                db.ReferelLabs.Add(referelLab);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            ReferelLabViewModel ReferelLabViewModel = new ReferelLabViewModel();
            ReferelLabViewModel.ReferelLabs = db.ReferelLabs.ToList();
            ReferelLabViewModel.ReferelLabName = referelLab.ReferelLabName;
            ReferelLabViewModel.Contact = referelLab.Contact;
            return View(ReferelLabViewModel);
        }

        // GET: ReferelLabs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferelLab referelLab = await db.ReferelLabs.FindAsync(id);
            if (referelLab == null)
            {
                return HttpNotFound();
            }

            ReferelLabViewModel ReferelLabViewModel = new ReferelLabViewModel();
            ReferelLabViewModel.ReferelLabs = db.ReferelLabs.ToList();
            ReferelLabViewModel.ReferelLabName = referelLab.ReferelLabName;
            ReferelLabViewModel.Contact = referelLab.Contact;
            ReferelLabViewModel.ReferelLabCode = referelLab.ReferelLabCode;
            return View(ReferelLabViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReferelLab referelLab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referelLab).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            ReferelLabViewModel ReferelLabViewModel = new ReferelLabViewModel();
            ReferelLabViewModel.ReferelLabs = db.ReferelLabs.ToList();
            ReferelLabViewModel.ReferelLabName = referelLab.ReferelLabName;
            ReferelLabViewModel.Contact = referelLab.Contact;
            ReferelLabViewModel.ReferelLabCode = referelLab.ReferelLabCode;
            return View(ReferelLabViewModel);
        }

        // GET: ReferelLabs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferelLab referelLab = await db.ReferelLabs.FindAsync(id);
            if (referelLab == null)
            {
                return HttpNotFound();
            }
            return View(referelLab);
        }

        // POST: ReferelLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ReferelLab referelLab = await db.ReferelLabs.FindAsync(id);
            db.ReferelLabs.Remove(referelLab);
            await db.SaveChangesAsync();
            return RedirectToAction("Create");
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
