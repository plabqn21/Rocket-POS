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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RamsoftBD.ModelView;

namespace RamsoftBD.Controllers
{
    public class CustomRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomRoles
        public async Task<ActionResult> Index()
        {
            return View(await db.CustomRoles.ToListAsync());
        }

        // GET: CustomRoles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = await db.CustomRoles.FindAsync(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // GET: CustomRoles/Create
        public ActionResult Create()
        {
            CustomRoleViewModel CustomRoleViewModel = new CustomRoleViewModel();
            CustomRoleViewModel.CustomRoles = db.CustomRoles.ToList();
            
            return View(CustomRoleViewModel);
        }

        // POST: CustomRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomRole customRole)
        {
            var existance = db.CustomRoles.FirstOrDefault(x => x.Name == customRole.Name);
            if (existance == null)
            {
                if (ModelState.IsValid)
                {
                    customRole.Id = customRole.Name;
                    db.CustomRoles.Add(customRole);
                    await db.SaveChangesAsync();


                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));


                    if (!roleManager.RoleExists(customRole.Name))
                    {
                        var role = new IdentityRole();
                        role.Id = customRole.Name;
                        role.Name = customRole.Name;
                        roleManager.Create(role);
                    }
                    return RedirectToAction("Create");
                }
            }

            else {
                ViewBag.existance = "This Role already exist";
            }
            CustomRoleViewModel CustomRoleViewModel = new CustomRoleViewModel();
            CustomRoleViewModel.CustomRoles = db.CustomRoles.ToList();
            CustomRoleViewModel.Id = customRole.Id;
            CustomRoleViewModel.Name = customRole.Name;
            return View(CustomRoleViewModel);
        }

        // GET: CustomRoles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = await db.CustomRoles.FindAsync(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }

            CustomRoleViewModel CustomRoleViewModel = new CustomRoleViewModel();
            CustomRoleViewModel.CustomRoles = db.CustomRoles.ToList();
            CustomRoleViewModel.Id = customRole.Id;
            CustomRoleViewModel.Name = customRole.Name;
            return View(CustomRoleViewModel);
        }

        // POST: CustomRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomRole customRole)
        {

            var existance = db.CustomRoles.FirstOrDefault(x => x.Name == customRole.Name);
            if (existance == null)
            {
                if (ModelState.IsValid)
                {

                    var role2 = db.Roles.Where(d => d.Id == customRole.Id).FirstOrDefault();
                    db.Roles.Remove(role2);
                    db.SaveChanges();
                    db.Entry(customRole).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));


                    if (!roleManager.RoleExists(customRole.Name))
                    {
                        var role = new IdentityRole();
                        role.Id = customRole.Name;
                        role.Name = customRole.Name;
                        roleManager.Create(role);
                    }


                    return RedirectToAction("Create");
                }
            }

            else {
                ViewBag.existance = "This Role already exist";
            }

            CustomRoleViewModel CustomRoleViewModel = new CustomRoleViewModel();
            CustomRoleViewModel.CustomRoles = db.CustomRoles.ToList();
            CustomRoleViewModel.Id = customRole.Id;
            CustomRoleViewModel.Name = customRole.Name;
            return View(CustomRoleViewModel);
        }

        // GET: CustomRoles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = await db.CustomRoles.FindAsync(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // POST: CustomRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CustomRole customRole = await db.CustomRoles.FindAsync(id);
            db.CustomRoles.Remove(customRole);
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
