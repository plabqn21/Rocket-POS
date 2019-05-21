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
    public class TestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        // GET: Tests/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = await db.Tests.FindAsync(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public async Task<ActionResult> Create()
        {
            TestViewModel TestViewModel = new TestViewModel();
            TestViewModel.Tests =await db.Tests.Include(a=>a.Unit).ToListAsync();
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.SpecimenId = new SelectList(db.Specimen, "Id", "SpecimenName");
            ViewBag.UnitId = new SelectList(db.Units, "Id", "UnitName");
            return View(TestViewModel);
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Test test)
        {
            if (ModelState.IsValid)
            {
                test.Id = Guid.NewGuid();
                var testCode = db.Tests.Max(x => x.TestCode) + 1;
                if (testCode == null) { testCode = 1; }
                test.TestCode = testCode;
                db.Tests.Add(test);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", test.DepartmentId);
            ViewBag.SpecimenId = new SelectList(db.Specimen, "Id", "SpecimenName", test.SpecimenId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "UnitName", test.UnitId);

            TestViewModel TestViewModel = new TestViewModel();
            TestViewModel.Tests = await db.Tests.Include(a => a.Unit).ToListAsync();
            TestViewModel.Id = test.Id;
            TestViewModel.TestName = test.TestName;
            TestViewModel.TestCode = test.TestCode;
            TestViewModel.Price = test.Price;
            TestViewModel.Discount = test.Discount;
            TestViewModel.DepartmentId = test.DepartmentId;
            TestViewModel.SpecimenId = test.SpecimenId;
            TestViewModel.Remarks = test.Remarks;
            TestViewModel.ReferenceValueMale = test.ReferenceValueMale;
            TestViewModel.ReferenceValueFeMale = test.ReferenceValueFeMale;
            TestViewModel.ReferenceValueChildren = test.ReferenceValueChildren;
            TestViewModel.UnitId = test.UnitId;

            return View(TestViewModel);
        }

        // GET: Tests/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = await db.Tests.FindAsync(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", test.DepartmentId);
            ViewBag.SpecimenId = new SelectList(db.Specimen, "Id", "SpecimenName", test.SpecimenId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "UnitName", test.UnitId);

            TestViewModel TestViewModel = new TestViewModel();
            TestViewModel.Tests = await db.Tests.Include(a => a.Unit).ToListAsync();
            TestViewModel.Id = test.Id;
            TestViewModel.TestName = test.TestName;
            TestViewModel.TestCode = test.TestCode;
            TestViewModel.Price = test.Price;
            TestViewModel.Discount = test.Discount;
            TestViewModel.DepartmentId = test.DepartmentId;
            TestViewModel.SpecimenId = test.SpecimenId;
            TestViewModel.Remarks = test.Remarks;
            TestViewModel.ReferenceValueMale = test.ReferenceValueMale;
            TestViewModel.ReferenceValueFeMale = test.ReferenceValueFeMale;
            TestViewModel.ReferenceValueChildren = test.ReferenceValueChildren;
            TestViewModel.UnitId = test.UnitId;
            return View(TestViewModel);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", test.DepartmentId);
            ViewBag.SpecimenId = new SelectList(db.Specimen, "Id", "SpecimenName", test.SpecimenId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "UnitName", test.UnitId);
            TestViewModel TestViewModel = new TestViewModel();
            TestViewModel.Tests = await db.Tests.Include(a => a.Unit).ToListAsync();
            TestViewModel.Id = test.Id;
            TestViewModel.TestName = test.TestName;
            TestViewModel.TestCode = test.TestCode;
            TestViewModel.Price = test.Price;
            TestViewModel.Discount = test.Discount;
            TestViewModel.DepartmentId = test.DepartmentId;
            TestViewModel.SpecimenId = test.SpecimenId;
            TestViewModel.Remarks = test.Remarks;
            TestViewModel.ReferenceValueMale = test.ReferenceValueMale;
            TestViewModel.ReferenceValueFeMale = test.ReferenceValueFeMale;
            TestViewModel.ReferenceValueChildren = test.ReferenceValueChildren;
            TestViewModel.UnitId = test.UnitId;
            return View(TestViewModel);
        }

        // GET: Tests/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = await db.Tests.FindAsync(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Test test = await db.Tests.FindAsync(id);
            db.Tests.Remove(test);
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
