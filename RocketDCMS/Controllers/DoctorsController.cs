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
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db =new ApplicationDbContext();
       

        // GET: Doctors/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            var doctors = db.Doctors.Include(d => d.Branch);
            DoctorViewModel DoctorViewModel = new DoctorViewModel();
            DoctorViewModel.Doctors = await doctors.ToListAsync();
            return View(DoctorViewModel);
        }



        // POST: Doctors/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.Id = Guid.NewGuid();

                var DoctorCode = db.Doctors.Max(x=>x.DoctorCode)+1;
                if (DoctorCode==null) { DoctorCode = 1; }
                doctor.DoctorCode = DoctorCode;
                db.Doctors.Add(doctor);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            var doctors = db.Doctors.Include(d => d.Branch);
            DoctorViewModel DoctorViewModel = new DoctorViewModel();
            DoctorViewModel.Doctors = await doctors.ToListAsync();
            return View(DoctorViewModel);
        }

        // GET: Doctors/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            var doctors = db.Doctors.Include(d => d.Branch);
            DoctorViewModel DoctorViewModel = new DoctorViewModel();
            DoctorViewModel.Id = doctor.Id;
            DoctorViewModel.DoctorName = doctor.DoctorName;
            DoctorViewModel.Qualification = doctor.Qualification;
            DoctorViewModel.Hospital = doctor.Hospital;
            DoctorViewModel.Type = doctor.Type;
            DoctorViewModel.Remarks = doctor.Remarks;
            DoctorViewModel.Branch = doctor.Branch;
            DoctorViewModel.BranchId = doctor.BranchId;
            DoctorViewModel.CommissionRate = doctor.CommissionRate;
            DoctorViewModel.DoctorCode = doctor.DoctorCode;
            DoctorViewModel.OldPatientFee = doctor.OldPatientFee;
            DoctorViewModel.OldPatientFeeDuration = doctor.OldPatientFeeDuration;
            DoctorViewModel.NewPatientFee = doctor.NewPatientFee;

            DoctorViewModel.Doctors = await doctors.ToListAsync();
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", doctor.BranchId);
            return View(DoctorViewModel);
        }


        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DoctorViewModel doctorViewModel)
        {
            Doctor Doctor=new Doctor();


            Doctor.Id = doctorViewModel.Id;
            Doctor.DoctorName = doctorViewModel.DoctorName;
            Doctor.Qualification = doctorViewModel.Qualification;
            Doctor.Hospital = doctorViewModel.Hospital;
            Doctor.Type = doctorViewModel.Type;
            Doctor.Remarks = doctorViewModel.Remarks;
            Doctor.Branch = doctorViewModel.Branch;
            Doctor.BranchId = doctorViewModel.BranchId;
            Doctor.CommissionRate = doctorViewModel.CommissionRate;
            Doctor.DoctorCode = doctorViewModel.DoctorCode;
            Doctor.NewPatientFee = doctorViewModel.NewPatientFee;
            Doctor.OldPatientFee = doctorViewModel.OldPatientFee;
            Doctor.OldPatientFeeDuration = doctorViewModel.OldPatientFeeDuration;

            if (ModelState.IsValid)
            {
              
                db.Entry(Doctor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            var doctors = db.Doctors.Include(d => d.Branch);

            doctorViewModel.Doctors = await doctors.ToListAsync();
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", doctorViewModel.BranchId);
            return View(doctorViewModel);
            
        }

        // GET: Doctors/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Doctor doctor = await db.Doctors.FindAsync(id);
            db.Doctors.Remove(doctor);
            await db.SaveChangesAsync();
            return RedirectToAction("Create");
        }


        // GET: Doctor/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var doctor =  db.Doctors.FirstOrDefault(x=>x.Id==id);
            ViewBag.BranchName= db.Branches.FirstOrDefault(x=>x.Id==doctor.BranchId).BranchName;
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
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
