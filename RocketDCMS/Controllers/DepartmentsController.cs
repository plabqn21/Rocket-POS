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
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

      
        // GET: Departments/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public async Task<ActionResult> Create()
        {
            DepartmentViewModel DepartmentViewModel = new DepartmentViewModel();
            DepartmentViewModel.Departments = await db.Departments.ToListAsync();
            return View(DepartmentViewModel);
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                department.Id = Guid.NewGuid();
                var DeptCode = db.Departments.Max(x => x.DepartmentCode) + 1;
                if (DeptCode == null) {
                    DeptCode = 1;
                }
                department.DepartmentCode = DeptCode;
                db.Departments.Add(department);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            DepartmentViewModel DepartmentViewModel = new DepartmentViewModel();
            DepartmentViewModel.Departments = await db.Departments.ToListAsync();

            DepartmentViewModel.Id = department.Id;
            DepartmentViewModel.DepartmentCode = department.DepartmentCode;
            DepartmentViewModel.DepartmentName = department.DepartmentName;
            DepartmentViewModel.Contact = department.Contact;
            DepartmentViewModel.Remarks = department.Remarks;
            return View(DepartmentViewModel);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }


            DepartmentViewModel DepartmentViewModel = new DepartmentViewModel();
            DepartmentViewModel.Departments = await db.Departments.ToListAsync();

            DepartmentViewModel.Id = department.Id;
            DepartmentViewModel.DepartmentCode = department.DepartmentCode;
            DepartmentViewModel.DepartmentName = department.DepartmentName;
            DepartmentViewModel.Contact = department.Contact;
            DepartmentViewModel.Remarks = department.Remarks;

            return View(DepartmentViewModel);
        }

        // GET: Departments/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Department department = await db.Departments.FindAsync(id);
            db.Departments.Remove(department);
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
