using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using RamsoftBD.Models;
using RamsoftBD.Models.Common;
using RamsoftBD.ModelView;

namespace RamsoftBD.Controllers
{
    public class HomeController : Controller
    { // Include this
       
        private ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        // You already have this
    
       
        public ActionResult Index()
        {

            var role = User.Identity.GetUserRole();



            var _menus = db.Permissions.Include("CustomRole").Include("SubMenu").Include("MainMenu").Where(x => x.CustomRoleId == role && x.Status == 1).Select(x => new MenuViewModel
            {
                MainMenuId = x.SubMenu.MainMenuId,
                MainMenuName = x.SubMenu.MainMenu.MainMenuName,
                SubMenuId = x.SubMenuId,
                SubMenuName = x.SubMenu.SubMenuName,
                ControllerName = x.SubMenu.Controller,
                ActionName = x.SubMenu.Action,
                RoleId = x.CustomRoleId,
                RoleName = x.CustomRole.Name
            }).OrderBy(x=>x.MainMenuName).ThenBy(x=>x.SubMenuName).ToList();


            Session["MenuMaster"] = _menus;

            return View();
        }



        public ActionResult Diagonostic_Home()
        {

           
            return View();
        }


    }
}