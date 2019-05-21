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
using RamsoftBD.Models.Common;
using RamsoftBD.ModelView;

namespace RamsoftBD.Controllers
{
    public class PermissionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult GetSubMenues(string MainMenuId)
        {

            

            var DistinctsubMenuList = db.SubMenus.Where(x=>x.MainMenuId== MainMenuId).ToList();




            return Json(DistinctsubMenuList, JsonRequestBehavior.AllowGet);
        }

        // GET: Permissions
        public async Task<ActionResult> Index()
        {
            var permissions = db.Permissions.Include(p => p.CustomRole).Include(p => p.MainMenu).Include(p => p.SubMenu);
            return View(await permissions.ToListAsync());
        }

        // GET: Permissions/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = await db.Permissions.FindAsync(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // GET: Permissions/Create
        public ActionResult Create()
        {
            ViewBag.CustomRoleId = new SelectList(db.CustomRoles, "Id", "Name");
            ViewBag.MainMenuId = new SelectList(db.MainMenus, "Id", "MainMenuName");
            var permissions = db.Permissions.Include(p => p.CustomRole).Include(p => p.MainMenu).Include(p => p.SubMenu);
            PermissionViewModel PermissionViewModel = new PermissionViewModel();
            PermissionViewModel.Permissions = permissions.ToList();
            return View(PermissionViewModel);
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Permission permission)
        {

            var existance = db.Permissions.FirstOrDefault(x => x.MainMenuId == permission.MainMenuId && x.SubMenuId == permission.SubMenuId && x.CustomRoleId == permission.CustomRoleId);

            if (existance == null)
            {
                if (ModelState.IsValid)
                {
                    permission.Id = Guid.NewGuid();
                    db.Permissions.Add(permission);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Create");
                }
            }
            else {
                ViewBag.existance = "This user already have this permission.";
                 }

            ViewBag.CustomRoleId = new SelectList(db.CustomRoles, "Id", "Name", permission.CustomRoleId);
            ViewBag.MainMenuId = new SelectList(db.MainMenus, "Id", "MainMenuName", permission.MainMenuId);
            var permissions = db.Permissions.Include(p => p.CustomRole).Include(p => p.MainMenu).Include(p => p.SubMenu);
            PermissionViewModel PermissionViewModel = new PermissionViewModel();
            PermissionViewModel.Permissions = permissions.ToList();
            PermissionViewModel.Id = permission.Id  ;
            PermissionViewModel.CustomRoleId = permission.CustomRoleId;
            PermissionViewModel.MainMenuId = permission.MainMenuId;
            PermissionViewModel.SubMenuId = permission.SubMenuId;
            PermissionViewModel.Status = permission.Status;
            return View(PermissionViewModel);
        }

        // GET: Permissions/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = await db.Permissions.FindAsync(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomRoleId = new SelectList(db.CustomRoles, "Id", "Name", permission.CustomRoleId);
            ViewBag.MainMenuId = new SelectList(db.MainMenus, "Id", "MainMenuName", permission.MainMenuId);
            ViewBag.SubMenuId = new SelectList(db.SubMenus, "Id", "SubMenuName", permission.SubMenuId);
            var permissions = db.Permissions.Include(p => p.CustomRole).Include(p => p.MainMenu).Include(p => p.SubMenu);
            PermissionViewModel PermissionViewModel = new PermissionViewModel();
            PermissionViewModel.Permissions = permissions.ToList();
            PermissionViewModel.Id = permission.Id;
            PermissionViewModel.CustomRoleId = permission.CustomRoleId;
            PermissionViewModel.MainMenuId = permission.MainMenuId;
            PermissionViewModel.SubMenuId = permission.SubMenuId;
            PermissionViewModel.Status = permission.Status;
            return View(PermissionViewModel);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Permission permission)
        {

            var existance = db.Permissions.FirstOrDefault(x => x.MainMenuId == permission.MainMenuId && x.SubMenuId == permission.SubMenuId && x.CustomRoleId == permission.CustomRoleId);
            if (existance == null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(permission).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Create");
                }
            }

            else
            {
                ViewBag.existance = "This user already have this permission.";
            }
            ViewBag.CustomRoleId = new SelectList(db.CustomRoles, "Id", "Name", permission.CustomRoleId);
            ViewBag.MainMenuId = new SelectList(db.MainMenus, "Id", "MainMenuName", permission.MainMenuId);
            ViewBag.SubMenuId = new SelectList(db.SubMenus, "Id", "SubMenuName", permission.SubMenuId);
              var permissions = db.Permissions.Include(p => p.CustomRole).Include(p => p.MainMenu).Include(p => p.SubMenu);
            PermissionViewModel PermissionViewModel = new PermissionViewModel();
            PermissionViewModel.Permissions = permissions.ToList();
            PermissionViewModel.Id = permission.Id  ;
            PermissionViewModel.CustomRoleId = permission.CustomRoleId;
            PermissionViewModel.MainMenuId = permission.MainMenuId;
            PermissionViewModel.SubMenuId = permission.SubMenuId;
            PermissionViewModel.Status = permission.Status;
            return View(PermissionViewModel);
        }

        // GET: Permissions/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = await db.Permissions.FindAsync(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Permission permission = await db.Permissions.FindAsync(id);
            db.Permissions.Remove(permission);
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
