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
using RamsoftBD.Models.POS;
using RamsoftBD.ModelView.POS;

namespace RamsoftBD.Controllers
{
    public class ItemUnitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: ItemUnits/Create
        public ActionResult Create()
        {
            ItemUnitViewModel ItemUnitViewModel = new ItemUnitViewModel();
            ItemUnitViewModel.ItemUnits = db.ItemUnits.ToList();
            return View(ItemUnitViewModel);
        }

        // POST: ItemUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ItemUnit itemUnit)
        {
            var item = db.ItemUnits.Where(x => x.Name == itemUnit.Name);

            if (item.Count() == 0)
            {
                if (ModelState.IsValid)
                {
                    itemUnit.Id = Guid.NewGuid();
                    db.ItemUnits.Add(itemUnit);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Create");
                }
            }

            else {

                ViewBag.Duplicate = "Already Exist";
            }
            ItemUnitViewModel ItemUnitViewModel = new ItemUnitViewModel();
            ItemUnitViewModel.ItemUnits = db.ItemUnits.ToList();
            ItemUnitViewModel.Id = itemUnit.Id;
            ItemUnitViewModel.Name = itemUnit.Name;
            return View(ItemUnitViewModel);
        }

        // GET: ItemUnits/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnit itemUnit = await db.ItemUnits.FindAsync(id);
            if (itemUnit == null)
            {
                return HttpNotFound();
            }


            ItemUnitViewModel ItemUnitViewModel = new ItemUnitViewModel();
            ItemUnitViewModel.ItemUnits = db.ItemUnits.ToList();
            ItemUnitViewModel.Id = itemUnit.Id;
            ItemUnitViewModel.Name = itemUnit.Name;
            return View(ItemUnitViewModel);
        }

        // POST: ItemUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ItemUnit itemUnit)
        {
            var item = db.ItemUnits.Where(x => x.Name == itemUnit.Name &&x.Id!= itemUnit.Id);

            if (item.Count() == 0)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(itemUnit).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Create");
                }
            }

            else
            {

                ViewBag.Duplicate = "Already Exist";
            }


            ItemUnitViewModel ItemUnitViewModel = new ItemUnitViewModel();
            ItemUnitViewModel.ItemUnits = db.ItemUnits.ToList();
            ItemUnitViewModel.Id = itemUnit.Id;
            ItemUnitViewModel.Name = itemUnit.Name;
            return View(ItemUnitViewModel);
        }

        // GET: ItemUnits/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnit itemUnit = await db.ItemUnits.FindAsync(id);
            if (itemUnit == null)
            {
                return HttpNotFound();
            }
            return View(itemUnit);
        }

        // POST: ItemUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ItemUnit itemUnit = await db.ItemUnits.FindAsync(id);
            db.ItemUnits.Remove(itemUnit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
