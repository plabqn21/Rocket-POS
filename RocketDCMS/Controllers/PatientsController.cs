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
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Patients/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create

        public async Task<ActionResult> Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            var patients = db.Patients.Include(p => p.Branch);
            PatientViewModel PatientViewModel = new PatientViewModel();
            PatientViewModel.Patients = await patients.ToListAsync();
            return View(PatientViewModel);
        }
    

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Patient patient)
        {
            if (ModelState.IsValid)
            {
                var counter = db.Patients.Max(x=>x.PatientCode)+1;

                if (counter == null) { counter = 1; }
                patient.Id = Guid.NewGuid();
                patient.PatientCode = counter;
                db.Patients.Add(patient);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            var patients = db.Patients.Include(p => p.Branch);
            PatientViewModel PatientViewModel = new PatientViewModel();
            PatientViewModel.Patients = await patients.ToListAsync();
            PatientViewModel.PatientName = patient.PatientName;
            PatientViewModel.Gender = patient.Gender;
            PatientViewModel.Age = patient.Age;
            PatientViewModel.AgeType = patient.AgeType;
            PatientViewModel.BloodGroup = patient.BloodGroup;
            PatientViewModel.Address = patient.Address;
            PatientViewModel.MobileNumber = patient.MobileNumber;
            PatientViewModel.Email = patient.Email;
            PatientViewModel.Remarks = patient.Remarks;
            PatientViewModel.Branch = patient.Branch;
            PatientViewModel.BranchId = patient.BranchId;
            PatientViewModel.PatientCode = patient.PatientCode;
            return View(PatientViewModel);
        }

        // GET: Patients/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", patient.BranchId);
            var patients = db.Patients.Include(p => p.Branch);
            PatientViewModel PatientViewModel = new PatientViewModel();
            PatientViewModel.Patients = await patients.ToListAsync();
            PatientViewModel.Id = patient.Id;
            PatientViewModel.PatientName = patient.PatientName;
            PatientViewModel.Gender = patient.Gender;
            PatientViewModel.Age = patient.Age;
            PatientViewModel.AgeType = patient.AgeType;
            PatientViewModel.BloodGroup = patient.BloodGroup;
            PatientViewModel.Address = patient.Address;
            PatientViewModel.MobileNumber = patient.MobileNumber;
            PatientViewModel.Email = patient.Email;
            PatientViewModel.Remarks = patient.Remarks;
            PatientViewModel.Branch = patient.Branch;
            PatientViewModel.BranchId = patient.BranchId;
            PatientViewModel.PatientCode = patient.PatientCode;
            
            return View(PatientViewModel);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientViewModel patientViewModel)
        {
            Patient patient = new Patient();
            patient.Id = patientViewModel.Id;

            patient.PatientName = patientViewModel.PatientName;
            patient.Gender = patientViewModel.Gender;
            patient.Age = patientViewModel.Age;
            patient.AgeType = patientViewModel.AgeType;
            patient.BloodGroup = patientViewModel.BloodGroup;
            patient.Address = patientViewModel.Address;
            patient.MobileNumber = patientViewModel.MobileNumber;
            patient.Email = patientViewModel.Email;
            patient.Remarks = patientViewModel.Remarks;
            patient.Branch = patientViewModel.Branch;
            patient.BranchId = patientViewModel.BranchId;
            patient.PatientCode = patientViewModel.PatientCode;

            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", patientViewModel.BranchId);
            var patients = db.Patients.Include(p => p.Branch);

            patientViewModel.Patients = await patients.ToListAsync();
            return View(patientViewModel);
        }

        // GET: Patients/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Patient patient = await db.Patients.FindAsync(id);
            db.Patients.Remove(patient);
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
