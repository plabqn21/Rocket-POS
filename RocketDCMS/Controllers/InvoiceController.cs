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
using System.Web.Routing;

namespace RamsoftBD.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var counter = db.Patients.Max(x => x.PatientCode)+1;
                if (counter == null || counter==0) { counter = 1; }
                patient.Id = Guid.NewGuid();
                patient.PatientCode = counter;
                db.Patients.Add(patient);
                 db.SaveChanges();

                return RedirectToAction("DoctorCreation", new
                {
                    Patient_Id = patient.Id

                });

            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            var patients = db.Patients.Include(p => p.Branch);
            PatientViewModel PatientViewModel = new PatientViewModel();
            PatientViewModel.Patients =  patients.ToList();
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
            return View(PatientViewModel);
        }

        // POST: Patients/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientViewModel patientViewModel)
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

            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("DoctorCreation", new
                {
                    Patient_Id = patient.Id

                });
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", patientViewModel.BranchId);
            var patients = db.Patients.Include(p => p.Branch);

            patientViewModel.Patients =  patients.ToList();
            return View(patientViewModel);
        }

        public async Task<ActionResult> DoctorCreation(Guid Patient_Id)
        {

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            var doctors = db.Doctors.Include(d => d.Branch);
            DoctorViewModelForInvoice DoctorViewModelForInvoice = new DoctorViewModelForInvoice();
            DoctorViewModelForInvoice.Doctors = await doctors.ToListAsync();
            DoctorViewModelForInvoice.Patient_Id = Patient_Id;
            return View(DoctorViewModelForInvoice);
        }



        // POST: Doctors/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorCreation(DoctorViewModelForInvoice DoctorViewModelForInvoice)
        {

            Doctor Doctor = new Doctor();



            Doctor.DoctorName = DoctorViewModelForInvoice.DoctorName;
            Doctor.Qualification = DoctorViewModelForInvoice.Qualification;
            Doctor.Hospital = DoctorViewModelForInvoice.Hospital;
            Doctor.Type = DoctorViewModelForInvoice.Type;
            Doctor.Remarks = DoctorViewModelForInvoice.Remarks;
            Doctor.Branch = DoctorViewModelForInvoice.Branch;
            Doctor.BranchId = DoctorViewModelForInvoice.BranchId;
            Doctor.CommissionRate = DoctorViewModelForInvoice.CommissionRate;
            Doctor.DoctorCode = DoctorViewModelForInvoice.DoctorCode;
            Doctor.NewPatientFee = DoctorViewModelForInvoice.NewPatientFee;
            Doctor.OldPatientFee = DoctorViewModelForInvoice.OldPatientFee;
            Doctor.OldPatientFeeDuration = DoctorViewModelForInvoice.OldPatientFeeDuration;
            if (ModelState.IsValid)
                if (ModelState.IsValid)
            {
                Doctor.Id = Guid.NewGuid();

                var counter = db.Doctors.Max(x => x.DoctorCode)+1;
                if (counter==null) { counter = 1; }
                Doctor.DoctorCode = counter;
                db.Doctors.Add(Doctor);
                 db.SaveChanges();


                return RedirectToAction("InvoiceCreate", new
                {
                    Patient_Id = DoctorViewModelForInvoice.Patient_Id,
                    Doctor_Id = Doctor.Id

                });
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            var doctors = db.Doctors.Include(d => d.Branch);

            DoctorViewModelForInvoice.Doctors =  doctors.ToList();
            return View(DoctorViewModelForInvoice);
        }


        // GET: Doctors/Edit/5
        public async Task<ActionResult> DoctorEdit(Guid? id, Guid? Patient_Id)
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
            DoctorViewModelForInvoice DoctorViewModelForInvoice = new DoctorViewModelForInvoice();
            DoctorViewModelForInvoice.Id = doctor.Id;
            DoctorViewModelForInvoice.DoctorName = doctor.DoctorName;
            DoctorViewModelForInvoice.Qualification = doctor.Qualification;
            DoctorViewModelForInvoice.Hospital = doctor.Hospital;
            DoctorViewModelForInvoice.Type = doctor.Type;
            DoctorViewModelForInvoice.Remarks = doctor.Remarks;
            DoctorViewModelForInvoice.Branch = doctor.Branch;
            DoctorViewModelForInvoice.BranchId = doctor.BranchId;
            DoctorViewModelForInvoice.CommissionRate = doctor.CommissionRate;
            DoctorViewModelForInvoice.DoctorCode = doctor.DoctorCode;
            DoctorViewModelForInvoice.Patient_Id = Patient_Id;
            DoctorViewModelForInvoice.NewPatientFee = doctor.NewPatientFee;
            DoctorViewModelForInvoice.OldPatientFee = doctor.OldPatientFee;
            DoctorViewModelForInvoice.OldPatientFeeDuration = doctor.OldPatientFeeDuration;
            DoctorViewModelForInvoice.Doctors = await doctors.ToListAsync();
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", doctor.BranchId);
            return View(DoctorViewModelForInvoice);
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult DoctorEdit(DoctorViewModelForInvoice DoctorViewModelForInvoice)
        {
            Doctor Doctor = new Doctor();


            Doctor.Id = DoctorViewModelForInvoice.Id;
            Doctor.DoctorName = DoctorViewModelForInvoice.DoctorName;
            Doctor.Qualification = DoctorViewModelForInvoice.Qualification;
            Doctor.Hospital = DoctorViewModelForInvoice.Hospital;
            Doctor.Type = DoctorViewModelForInvoice.Type;
            Doctor.Remarks = DoctorViewModelForInvoice.Remarks;
            Doctor.Branch = DoctorViewModelForInvoice.Branch;
            Doctor.BranchId = DoctorViewModelForInvoice.BranchId;
            Doctor.CommissionRate = DoctorViewModelForInvoice.CommissionRate;
            Doctor.DoctorCode = DoctorViewModelForInvoice.DoctorCode;
            Doctor.NewPatientFee = DoctorViewModelForInvoice.NewPatientFee;
            Doctor.OldPatientFee = DoctorViewModelForInvoice.OldPatientFee;
            Doctor.OldPatientFeeDuration = DoctorViewModelForInvoice.OldPatientFeeDuration;

            if (ModelState.IsValid)
            {

                db.Entry(Doctor).State = EntityState.Modified;

                 db.SaveChanges();
                return RedirectToAction("InvoiceCreate", new
                {
                    Patient_Id = DoctorViewModelForInvoice.Patient_Id,
                    Doctor_Id = Doctor.Id

                });
            }
            var doctors = db.Doctors.Include(d => d.Branch);

            DoctorViewModelForInvoice.Doctors =  doctors.ToList();
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", DoctorViewModelForInvoice.BranchId);
            return View(DoctorViewModelForInvoice);

        }

        [HttpGet]
        public async Task<ActionResult> InvoiceCreate(Guid Doctor_Id, Guid Patient_Id)
        {


            InvoiceViewModel InvoiceViewModel = new InvoiceViewModel();
            InvoiceViewModel.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Doctor_Id);
            InvoiceViewModel.Patient = db.Patients.SingleOrDefault(x => x.Id == Patient_Id);
            InvoiceViewModel.Tests = await db.Tests.Include(t => t.Department).Include(t => t.Specimen).Include(t => t.Unit).ToListAsync();

            return View(InvoiceViewModel);

        }

        // POST: InvoiceCreate
        [HttpPost]

        public ActionResult InvoiceCreate(List<TestViewModelForInvoice> TestViewModelForInvoice)
        {
            if (TestViewModelForInvoice != null)
            {

                var OrderNumber = db.Orders.Max(x => x.OrderCode) + 1;
                if (OrderNumber == null) { OrderNumber = 1; }
                foreach (var Clientorder in TestViewModelForInvoice) {

                    Order order = new Order();
                    order.Id = Guid.NewGuid();
                    order.OrderCode = OrderNumber;
                    order.TestCode = Clientorder.TestCode;
                    order.PatientId = Clientorder.Patient_Id;
                    order.DoctorId = Clientorder.Doctor_Id;
                    order.TestId = db.Tests.SingleOrDefault(x => x.TestCode == Clientorder.TestCode).Id; ;
                    order.OrderDate = DateTime.Now;
                    order.Branch_Id = Guid.Parse(User.Identity.GetUserBranchId());

                    db.Orders.Add(order);
                     db.SaveChanges();

                }

                var response = new
                {
                    Patient_Id = TestViewModelForInvoice[0].Patient_Id,
                    Doctor_Id = TestViewModelForInvoice[0].Doctor_Id,
                    OrderNumber = OrderNumber

                };
                return Json(response, "response", JsonRequestBehavior.AllowGet); ;
              
            }


            return Content("Fail");

        }


 
        public  ActionResult InvoiceCheckOut(Guid Doctor_Id, Guid Patient_Id,long OrderNumber)
        {

            InvoiceCheckoutViewModel InvoiceCheckoutViewModel = new InvoiceCheckoutViewModel();

            InvoiceCheckoutViewModel.Doctor_Id = Doctor_Id;
            InvoiceCheckoutViewModel.Patient_Id = Patient_Id;
            InvoiceCheckoutViewModel.OrderNumber = OrderNumber;
            InvoiceCheckoutViewModel.Branch_Id = Guid.Parse(User.Identity.GetUserBranchId());
            InvoiceCheckoutViewModel.Bill_Generator = Guid.Parse(User.Identity.GetUser_Id());
            InvoiceCheckoutViewModel.TotalBill = (from T in db.Tests
                                                         join O in db.Orders on T.Id equals O.TestId
                                                         where O.PatientId== Patient_Id && O.OrderCode== OrderNumber 
                                                         && O.DoctorId== Doctor_Id
                                                         select T.Price).Sum() ;

            /// To Do Individual Test Discount not considered
            InvoiceCheckoutViewModel.TotalPayable = InvoiceCheckoutViewModel.TotalBill;
            ViewBag.ReferelLabId = new SelectList(db.ReferelLabs, "Id", "ReferelLabName");
            return View(InvoiceCheckoutViewModel);

        }
        [HttpPost]

        public ActionResult InvoiceCheckOut(InvoiceCheckoutViewModel InvoiceCheckoutViewModel)
        {
            if (InvoiceCheckoutViewModel != null)
            {

              var data =  db.InvoiceCheckouts.FirstOrDefault(x=>x.OrderNumber== InvoiceCheckoutViewModel.OrderNumber);

                if (data !=null)
                {
                    db.InvoiceCheckouts.Remove(data);
                     db.SaveChanges();
                }

                InvoiceCheckout invoiceCheckout = new InvoiceCheckout();
                invoiceCheckout.Id = Guid.NewGuid();

                invoiceCheckout.Doctor_Id = InvoiceCheckoutViewModel.Doctor_Id;
                invoiceCheckout.Patient_Id = InvoiceCheckoutViewModel.Patient_Id;
                invoiceCheckout.OrderNumber = InvoiceCheckoutViewModel.OrderNumber;
                invoiceCheckout.TotalPayable = InvoiceCheckoutViewModel.TotalPayable;
                invoiceCheckout.Branch_Id = InvoiceCheckoutViewModel.Branch_Id;

                invoiceCheckout.Bill_Generator = InvoiceCheckoutViewModel.Bill_Generator;

                invoiceCheckout.InvoiceDate = InvoiceCheckoutViewModel.InvoiceDate;

                invoiceCheckout.PaymentMode = InvoiceCheckoutViewModel.PaymentMode;

                invoiceCheckout.PaymentMethod = InvoiceCheckoutViewModel.PaymentMethod;

                invoiceCheckout.TotalBill = InvoiceCheckoutViewModel.TotalBill;
                invoiceCheckout.Discount = InvoiceCheckoutViewModel.Discount;

                invoiceCheckout.SampleReceiveDate = InvoiceCheckoutViewModel.SampleReceiveDate;
                invoiceCheckout.SampleReceiveTime = InvoiceCheckoutViewModel.SampleReceiveTime;

                invoiceCheckout.IsCorporateCustomer = InvoiceCheckoutViewModel.IsCorporateCustomer;


                invoiceCheckout.ReferelLabId = InvoiceCheckoutViewModel.ReferelLabId;


                invoiceCheckout.Remarks = InvoiceCheckoutViewModel.Remarks;

                invoiceCheckout.ReportDeliveryDate = InvoiceCheckoutViewModel.ReportDeliveryDate;

                invoiceCheckout.ReportDeliveryTime = InvoiceCheckoutViewModel.ReportDeliveryTime;

                db.InvoiceCheckouts.Add(invoiceCheckout);
                db.SaveChanges();


                var ExistData = db.BillTransactions.FirstOrDefault(x => x.OrderNumber == InvoiceCheckoutViewModel.OrderNumber);

                if (ExistData != null)
                {
                    db.BillTransactions.Remove(ExistData);
                    db.SaveChanges();
                }


                BillTransaction billTransaction = new BillTransaction();
                billTransaction.Id = Guid.NewGuid();
                billTransaction.OrderNumber = InvoiceCheckoutViewModel.OrderNumber;
                billTransaction.Patient_Id = InvoiceCheckoutViewModel.Patient_Id;
                billTransaction.Doctor_Id = InvoiceCheckoutViewModel.Doctor_Id;
                billTransaction.Branch_Id = InvoiceCheckoutViewModel.Branch_Id;
                billTransaction.BillDate = InvoiceCheckoutViewModel.InvoiceDate;
                billTransaction.Transtype = "Bill";
                
                billTransaction.BillAmount = InvoiceCheckoutViewModel.TotalPayable;
                db.BillTransactions.Add(billTransaction);
                db.SaveChanges();


                var existingDataPaymentTrans = db.PaymentTransactions.Where(x => x.OrderNumber == InvoiceCheckoutViewModel.OrderNumber);
                if (existingDataPaymentTrans.Count() != 0) {

                    db.ExecuteNonQuery("Delete from PaymentTransactions where OrderNumber='"+ InvoiceCheckoutViewModel.OrderNumber+"'");

                }
                if (InvoiceCheckoutViewModel.AmountReceived > 0) {
                    PaymentTransaction PaymentTransaction = new PaymentTransaction();
                    PaymentTransaction.Id = Guid.NewGuid();
                    PaymentTransaction.OrderNumber = InvoiceCheckoutViewModel.OrderNumber;
                    PaymentTransaction.Patient_Id = InvoiceCheckoutViewModel.Patient_Id;
                    PaymentTransaction.Doctor_Id = InvoiceCheckoutViewModel.Doctor_Id;
                    PaymentTransaction.Branch_Id = InvoiceCheckoutViewModel.Branch_Id;
                    PaymentTransaction.PaymentDate = InvoiceCheckoutViewModel.InvoiceDate;
                    PaymentTransaction.Transtype = "Payment";
                    PaymentTransaction.TransAmount = InvoiceCheckoutViewModel.AmountReceived;
                    db.PaymentTransactions.Add(PaymentTransaction);
                    db.SaveChanges();

                }

                return RedirectToAction("InvoiceCheckOut", new
                {
                    Doctor_Id = InvoiceCheckoutViewModel.Doctor_Id,
                    Patient_Id= InvoiceCheckoutViewModel.Patient_Id,
                    OrderNumber= InvoiceCheckoutViewModel.OrderNumber
                });

            }
            ViewBag.ReferelLabId = new SelectList(db.ReferelLabs, "Id", "ReferelLabName");
            return View(InvoiceCheckoutViewModel);

        }




        [HttpGet]
        public ActionResult InvoiceSearch(string Message)
        {

            InvoiceUpdateViewModel InvoiceUpdateViewModel = new InvoiceUpdateViewModel();
          
           InvoiceViewModel InvoiceViewModel = new InvoiceViewModel();

            InvoiceViewModel.Tests = new List<Test>();
            InvoiceViewModel.Doctor = new Doctor();
            InvoiceViewModel.Patient = new Patient();

            InvoiceUpdateViewModel.InvoiceViewModel = InvoiceViewModel;

            ViewBag.Message = Message;

            return View(InvoiceUpdateViewModel);
        }




        [HttpPost]
        public ActionResult InvoiceSearchResult(InvoiceUpdateViewModel InvoiceUpdateView) {

            InvoiceUpdateViewModel InvoiceUpdateViewModel = new InvoiceUpdateViewModel();
            if (InvoiceUpdateView.OrderNumber != 0 && InvoiceUpdateView.OrderNumber!=null)
            {
                var order = db.Orders.Include(a=>a.Test).Where(x => x.OrderCode == InvoiceUpdateView.OrderNumber).ToList();

                if (order.Count!=0)
                {
                    var singleOrder = order.FirstOrDefault(a => a.OrderCode == InvoiceUpdateView.OrderNumber);
                    InvoiceViewModel InvoiceViewModel = new InvoiceViewModel();
                    InvoiceViewModel.Doctor = db.Doctors.FirstOrDefault(x => x.Id == singleOrder.DoctorId);
                    InvoiceViewModel.Patient = db.Patients.FirstOrDefault(x => x.Id == singleOrder.PatientId);
                    InvoiceViewModel.Tests = db.Tests.Include(t => t.Department).Include(t => t.Specimen).Include(t => t.Unit).ToList();

                    InvoiceUpdateViewModel.Orders = order;
                    InvoiceUpdateViewModel.OrderNumber = InvoiceUpdateView.OrderNumber;
                    InvoiceUpdateViewModel.InvoiceViewModel = InvoiceViewModel;
                }

                else {
                    return RedirectToAction("InvoiceSearch", new
                    {
                        Message = "No data found with this order number."

                    });

                }

            }

            return View(InvoiceUpdateViewModel);
        }

        [HttpPost]
        public ActionResult InvoiceUpdate(List<TestViewModelForInvoice> TestViewModelForInvoice)
        {


            if (TestViewModelForInvoice != null)
            {


                var orderNumber = TestViewModelForInvoice[0].OrderNumber;

             

                    db.ExecuteNonQuery("DELETE FROM Orders WHERE OrderCode = " + orderNumber);
                    db.ExecuteNonQuery("DELETE FROM InvoiceCheckouts WHERE OrderNumber = " + orderNumber);
                    db.ExecuteNonQuery("DELETE FROM BillTransactions WHERE OrderNumber = " + orderNumber);
                    db.ExecuteNonQuery("DELETE FROM PaymentTransactions WHERE OrderNumber = " + orderNumber);


                foreach (var Clientorder in TestViewModelForInvoice)
                {

                    Order order = new Order();
                    order.Id = Guid.NewGuid();
                    order.OrderCode = orderNumber;
                    order.PatientId = Clientorder.Patient_Id;
                    order.DoctorId = Clientorder.Doctor_Id;
                    order.TestId = db.Tests.SingleOrDefault(x=>x.TestCode== Clientorder.TestCode).Id;
                    order.TestCode = Clientorder.TestCode;
                    order.OrderDate = DateTime.Now;
                    order.Branch_Id = Guid.Parse(User.Identity.GetUserBranchId());

                    db.Orders.Add(order);
                    db.SaveChanges();

                }

                var response = new
                {
                    Patient_Id = TestViewModelForInvoice[0].Patient_Id,
                    Doctor_Id = TestViewModelForInvoice[0].Doctor_Id,
                    OrderNumber = orderNumber

                };
                return Json(response, "response", JsonRequestBehavior.AllowGet); ;

            }


            return Content("Fail");
        }

        [HttpGet]
        public ActionResult DuePayment( string Message )
        {

            ViewBag.Message = Message;
            return View();
        }

        [HttpPost]
        public ActionResult DuePayment(InvoiceUpdateViewModel InvoiceUpdateViewModel)
        {


            return RedirectToAction("DuePaymentSearchResult", new
            {
                OrderNumber = InvoiceUpdateViewModel.OrderNumber

            });
        }

        [HttpGet]
        public ActionResult DuePaymentSearchResult(long OrderNumber)
        {
            DuePaymentViewModel DuePaymentViewModel = new DuePaymentViewModel();

            var  billTransactionCounter = db.BillTransactions.Where(x => x.OrderNumber == OrderNumber && x.Transtype == "Bill").Count();
            if (billTransactionCounter == 1)
            {
                var billTransaction = db.BillTransactions.SingleOrDefault(x => x.OrderNumber == OrderNumber && x.Transtype == "Bill");



                var patient = db.Patients.SingleOrDefault(x => x.Id == billTransaction.Patient_Id);
                DuePaymentViewModel.BillTransaction = billTransaction;
                DuePaymentViewModel.Patient = patient;
                DuePaymentViewModel.PaymentTransactions = db.PaymentTransactions.Where(x => x.OrderNumber == OrderNumber).ToList();
                DuePaymentViewModel.PaymentTransactionSum = DuePaymentViewModel.PaymentTransactions.Sum(x => x.TransAmount);
                DuePaymentViewModel.TotalDue = DuePaymentViewModel.BillTransaction.BillAmount - DuePaymentViewModel.PaymentTransactionSum;
                DuePaymentViewModel.Doctor = db.Doctors.SingleOrDefault(x => x.Id == billTransaction.Doctor_Id);
                DuePaymentViewModel.InvoiceCheckout = db.InvoiceCheckouts.SingleOrDefault(x => x.OrderNumber == OrderNumber);
            }
            else if(billTransactionCounter==0)
            {
                return RedirectToAction("DuePayment", new
                {
                    Message = "No data found with this order number."

            });


               
            }
            else

            {
                return RedirectToAction("DuePayment", new
                {
                    Message = "Multiple Order by One Oder Number. Please Contact with Database Administrator."

                });

               
            }



            return View(DuePaymentViewModel);
        }


        [HttpPost]
        public ActionResult DuePaymentSearchResult(DuePaymentViewModel DuePaymentViewModel)
        {
            if (DuePaymentViewModel.TransAmount > 0)
            {
                PaymentTransaction PaymentTransaction = new PaymentTransaction();
                PaymentTransaction.Id = Guid.NewGuid();
                PaymentTransaction.OrderNumber = DuePaymentViewModel.BillTransaction.OrderNumber;
                PaymentTransaction.Patient_Id = DuePaymentViewModel.Patient.Id;
                PaymentTransaction.Doctor_Id = DuePaymentViewModel.Doctor.Id;
                PaymentTransaction.Branch_Id = DuePaymentViewModel.BillTransaction.Branch_Id;
                PaymentTransaction.PaymentDate = DateTime.Now;
                PaymentTransaction.Transtype = "Payment";
                PaymentTransaction.TransAmount = DuePaymentViewModel.TransAmount;
                db.PaymentTransactions.Add(PaymentTransaction);
                db.SaveChanges();

            }
            var OrderNumber = DuePaymentViewModel.BillTransaction.OrderNumber;
            var billTransaction = db.BillTransactions.SingleOrDefault(x => x.OrderNumber == OrderNumber && x.Transtype == "Bill");



            var patient = db.Patients.SingleOrDefault(x => x.Id == billTransaction.Patient_Id);
            DuePaymentViewModel.BillTransaction = billTransaction;
            DuePaymentViewModel.Patient = patient;
            DuePaymentViewModel.PaymentTransactions = db.PaymentTransactions.Where(x => x.OrderNumber == OrderNumber).ToList();
            DuePaymentViewModel.PaymentTransactionSum = DuePaymentViewModel.PaymentTransactions.Sum(x => x.TransAmount);
            DuePaymentViewModel.TotalDue = DuePaymentViewModel.BillTransaction.BillAmount - DuePaymentViewModel.PaymentTransactionSum;
            DuePaymentViewModel.Doctor = db.Doctors.SingleOrDefault(x => x.Id == billTransaction.Doctor_Id);
            DuePaymentViewModel.InvoiceCheckout = db.InvoiceCheckouts.SingleOrDefault(x => x.OrderNumber == OrderNumber);




            return View(DuePaymentViewModel);
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
