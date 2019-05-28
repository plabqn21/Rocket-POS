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
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Items
        public async Task<ActionResult> Index()
        {
            var items = db.Items.Include(i => i.Branch).Include(i => i.ItemCatagory).Include(i => i.ItemSubCatagory).Include(i => i.ItemUnit).Include(i => i.Supplier);
            return View(await items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name");
            ViewBag.ItemSubCatagoryId = new SelectList(db.ItemSubCatagories, "Id", "Name");
            ViewBag.ItemUnitId = new SelectList(db.ItemUnits, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Code,Details,ItemCatagoryId,ItemSubCatagoryId,ItemUnitId,SupplierId,Price,Discount,BranchId")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid();
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", item.BranchId);
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name", item.ItemCatagoryId);
            ViewBag.ItemSubCatagoryId = new SelectList(db.ItemSubCatagories, "Id", "Name", item.ItemSubCatagoryId);
            ViewBag.ItemUnitId = new SelectList(db.ItemUnits, "Id", "Name", item.ItemUnitId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", item.SupplierId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", item.BranchId);
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name", item.ItemCatagoryId);
            ViewBag.ItemSubCatagoryId = new SelectList(db.ItemSubCatagories, "Id", "Name", item.ItemSubCatagoryId);
            ViewBag.ItemUnitId = new SelectList(db.ItemUnits, "Id", "Name", item.ItemUnitId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", item.SupplierId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Code,Details,ItemCatagoryId,ItemSubCatagoryId,ItemUnitId,SupplierId,Price,Discount,BranchId")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", item.BranchId);
            ViewBag.ItemCatagoryId = new SelectList(db.ItemCatagories, "Id", "Name", item.ItemCatagoryId);
            ViewBag.ItemSubCatagoryId = new SelectList(db.ItemSubCatagories, "Id", "Name", item.ItemSubCatagoryId);
            ViewBag.ItemUnitId = new SelectList(db.ItemUnits, "Id", "Name", item.ItemUnitId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", item.SupplierId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
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
