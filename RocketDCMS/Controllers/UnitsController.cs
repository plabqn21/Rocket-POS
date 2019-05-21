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
    public class UnitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


     

        // GET: Units/Create
        public async Task<ActionResult> Create()
        {

            UnitViewModel UnitViewModel = new UnitViewModel();

            UnitViewModel.Units =await db.Units.ToListAsync();
            return View(UnitViewModel);
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( UnitViewModel UnitViewModel)
        {
            Unit unit = new Unit();
            unit.UnitName = UnitViewModel.UnitName;
            unit.Remarks = UnitViewModel.Remarks;
            if (unit!=null)
            {
                unit.Id = Guid.NewGuid();
                var UnitCode = db.Units.Max(x => x.UnitCode) + 1;
                if (UnitCode == null) { UnitCode = 1; }
                unit.UnitCode = UnitCode;
                db.Units.Add(unit);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            return View(UnitViewModel);
        }

        // GET: Units/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }

            UnitViewModel UnitViewModel = new UnitViewModel();

            UnitViewModel.Units = await db.Units.ToListAsync();
            UnitViewModel.Id = unit.Id;
            UnitViewModel.UnitName = unit.UnitName;
            UnitViewModel.UnitCode = unit.UnitCode;
            UnitViewModel.Remarks = unit.Remarks;
            return View(UnitViewModel);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Unit unit)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            UnitViewModel UnitViewModel = new UnitViewModel();
            UnitViewModel.Units =await db.Units.ToListAsync();
            UnitViewModel.Id = unit.Id;
            UnitViewModel.UnitCode = unit.UnitCode;
            UnitViewModel.UnitName = unit.UnitName;
            UnitViewModel.Remarks = unit.Remarks;
            return View(UnitViewModel);
        }

        // GET: Units/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Unit unit = await db.Units.FindAsync(id);
            db.Units.Remove(unit);
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
