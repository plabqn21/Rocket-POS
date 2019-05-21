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
  
    public class BranchesController : Controller
    {

        private ApplicationDbContext db=new ApplicationDbContext();
      


        // GET: Branches/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branches/Create
        public async Task<ActionResult> Create()
        {
            BranchViewModel branchViewModel = new BranchViewModel();
            branchViewModel.Branches = await db.Branches.ToListAsync();
            return View(branchViewModel);
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                branch.Id = Guid.NewGuid();
                var BranchCode = db.Branches.Max(x=>x.BranchCode)+1 ;
                if (BranchCode == null) { BranchCode = 1; }
                branch.BranchCode = BranchCode;
                db.Branches.Add(branch);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            BranchViewModel branchViewModel = new BranchViewModel();
            branchViewModel.Branches = await db.Branches.ToListAsync();           
            branchViewModel.BranchName = branch.BranchName;
            branchViewModel.BranchCode = branch.BranchCode;
            branchViewModel.Address = branch.Address;
            branchViewModel.BranchStatus = branch.BranchStatus;
            branchViewModel.OpeningDate = branch.OpeningDate;
            branchViewModel.CloseDate = branch.CloseDate;


            return View(branchViewModel);
        }

        // GET: Branches/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }



            BranchViewModel branchViewModel = new BranchViewModel();
            branchViewModel.Branches = await db.Branches.ToListAsync();
            branchViewModel.Id = branch.Id;
            branchViewModel.BranchName = branch.BranchName;
            branchViewModel.BranchCode = branch.BranchCode;
            branchViewModel.Address = branch.Address;
            branchViewModel.BranchStatus = branch.BranchStatus;
            branchViewModel.OpeningDate = branch.OpeningDate;
            branchViewModel.CloseDate = branch.CloseDate;

            return View(branchViewModel);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            BranchViewModel branchViewModel = new BranchViewModel();
            branchViewModel.Branches = await db.Branches.ToListAsync();
            branchViewModel.Id = branch.Id;
            branchViewModel.BranchName = branch.BranchName;
            branchViewModel.BranchCode = branch.BranchCode;
            branchViewModel.Address = branch.Address;
            branchViewModel.BranchStatus = branch.BranchStatus;
            branchViewModel.OpeningDate = branch.OpeningDate;
            branchViewModel.CloseDate = branch.CloseDate;
            return View(branchViewModel);
        }

        // GET: Branches/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Branch branch = await db.Branches.FindAsync(id);
            db.Branches.Remove(branch);
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
