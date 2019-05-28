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
    public class ItemSubCatagoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemSubCatagories
        public async Task<ActionResult> Index()
        {
            var itemSubCatagories = db.ItemSubCatagories.Include(i => i.Branch).Include(i => i.ItemCatagory);
            return View(await itemSubCatagories.ToListAsync());
        }

        // GET: ItemSubCatagories/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCatagory itemSubCatagory = await db.ItemSubCatagories.FindAsync(id);
            if (itemSubCatagory == null)
            {
                return HttpNotFound();
            }
            return View(itemSubCatagory);
        }

        // GET: ItemSubCatagories/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name");
            return View();
        }

        // POST: ItemSubCatagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Code,Details,ItemCatagoryId,BranchId")] ItemSubCatagory itemSubCatagory)
        {
            if (ModelState.IsValid)
            {
                itemSubCatagory.Id = Guid.NewGuid();
                db.ItemSubCatagories.Add(itemSubCatagory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", itemSubCatagory.BranchId);
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name", itemSubCatagory.ItemCatagoryId);
            return View(itemSubCatagory);
        }

        // GET: ItemSubCatagories/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCatagory itemSubCatagory = await db.ItemSubCatagories.FindAsync(id);
            if (itemSubCatagory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", itemSubCatagory.BranchId);
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name", itemSubCatagory.ItemCatagoryId);
            return View(itemSubCatagory);
        }

        // POST: ItemSubCatagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Code,Details,ItemCatagoryId,BranchId")] ItemSubCatagory itemSubCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemSubCatagory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", itemSubCatagory.BranchId);
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name", itemSubCatagory.ItemCatagoryId);
            return View(itemSubCatagory);
        }

        // GET: ItemSubCatagories/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCatagory itemSubCatagory = await db.ItemSubCatagories.FindAsync(id);
            if (itemSubCatagory == null)
            {
                return HttpNotFound();
            }
            return View(itemSubCatagory);
        }

        // POST: ItemSubCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ItemSubCatagory itemSubCatagory = await db.ItemSubCatagories.FindAsync(id);
            db.ItemSubCatagories.Remove(itemSubCatagory);
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
