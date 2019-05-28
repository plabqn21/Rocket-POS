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

namespace RamsoftBD.Controllers
{
    public class ItemCatagoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemCatagories
        public async Task<ActionResult> Index()
        {
            var itemCatagories = db.ItemCatagories.Include(i => i.Branch);
            return View(await itemCatagories.ToListAsync());
        }

        // GET: ItemCatagories/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCatagory itemCatagory = await db.ItemCatagories.FindAsync(id);
            if (itemCatagory == null)
            {
                return HttpNotFound();
            }
            return View(itemCatagory);
        }

        // GET: ItemCatagories/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            return View();
        }

        // POST: ItemCatagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Code,Details,TransactionMethod,BranchId")] ItemCatagory itemCatagory)
        {
            if (ModelState.IsValid)
            {
                itemCatagory.Id = Guid.NewGuid();
                db.ItemCatagories.Add(itemCatagory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", itemCatagory.BranchId);
            return View(itemCatagory);
        }

        // GET: ItemCatagories/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCatagory itemCatagory = await db.ItemCatagories.FindAsync(id);
            if (itemCatagory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", itemCatagory.BranchId);
            return View(itemCatagory);
        }

        // POST: ItemCatagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Code,Details,TransactionMethod,BranchId")] ItemCatagory itemCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemCatagory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", itemCatagory.BranchId);
            return View(itemCatagory);
        }

        // GET: ItemCatagories/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCatagory itemCatagory = await db.ItemCatagories.FindAsync(id);
            if (itemCatagory == null)
            {
                return HttpNotFound();
            }
            return View(itemCatagory);
        }

        // POST: ItemCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ItemCatagory itemCatagory = await db.ItemCatagories.FindAsync(id);
            db.ItemCatagories.Remove(itemCatagory);
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
