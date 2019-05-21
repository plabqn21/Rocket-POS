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
    public class SpecimensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        // GET: Specimens/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specimen specimen = await db.Specimen.FindAsync(id);
            if (specimen == null)
            {
                return HttpNotFound();
            }
            return View(specimen);
        }

        // GET: Specimens/Create
        public ActionResult Create()
        {

            SpecimenViewModel SpecimenViewModel = new SpecimenViewModel();
            SpecimenViewModel.Specimens = db.Specimen.ToList();
            return View(SpecimenViewModel);
        }

        // POST: Specimens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Specimen specimen)
        {
            if (ModelState.IsValid)
            {
                var sCode = db.Specimen.Max(x => x.SpecimenCode) + 1;
                if (sCode == null) {
                    sCode = 1;
                }
                specimen.SpecimenCode = sCode;
                specimen.Id = Guid.NewGuid();
                db.Specimen.Add(specimen);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            SpecimenViewModel SpecimenViewModel = new SpecimenViewModel();
            SpecimenViewModel.Specimens = await db.Specimen.ToListAsync();
            SpecimenViewModel.Id = specimen.Id;
            SpecimenViewModel.SpecimenCode = specimen.SpecimenCode;
            SpecimenViewModel.SpecimenName = specimen.SpecimenName;
            SpecimenViewModel.Remarks = specimen.Remarks;

            return View(specimen);
        }

        // GET: Specimens/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specimen specimen = await db.Specimen.FindAsync(id);
            if (specimen == null)
            {
                return HttpNotFound();
            }

            SpecimenViewModel SpecimenViewModel = new SpecimenViewModel();
            SpecimenViewModel.Specimens = await db.Specimen.ToListAsync();
            SpecimenViewModel.Id = specimen.Id;
            SpecimenViewModel.SpecimenCode = specimen.SpecimenCode;
            SpecimenViewModel.SpecimenName = specimen.SpecimenName;
            SpecimenViewModel.Remarks = specimen.Remarks;
            return View(SpecimenViewModel);
        }

        // POST: Specimens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Specimen specimen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specimen).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            SpecimenViewModel SpecimenViewModel = new SpecimenViewModel();
            SpecimenViewModel.Specimens = await db.Specimen.ToListAsync();
            SpecimenViewModel.Id = specimen.Id;
            SpecimenViewModel.SpecimenCode = specimen.SpecimenCode;
            SpecimenViewModel.SpecimenName = specimen.SpecimenName;
            SpecimenViewModel.Remarks = specimen.Remarks;
            return View(specimen);
        }

        // GET: Specimens/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specimen specimen = await db.Specimen.FindAsync(id);
            if (specimen == null)
            {
                return HttpNotFound();
            }
            return View(specimen);
        }

        // POST: Specimens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Specimen specimen = await db.Specimen.FindAsync(id);
            db.Specimen.Remove(specimen);
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
