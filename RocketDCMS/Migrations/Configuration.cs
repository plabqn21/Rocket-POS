namespace RamsoftBD.Migrations
{
    using RamsoftBD.Models.Common;
    using System;
    using RamsoftBD.Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<RamsoftBD.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RamsoftBD.Models.ApplicationDbContext context)
        {

            context.Branches.AddOrUpdate(x => x.BranchCode,
                new Branch() { Id = Guid.NewGuid(), BranchCode = 1, BranchName = "TestBranch", OpeningDate = DateTime.Now.Date, Address = "", CloseDate = null, BranchStatus = "Active" }


                );


            context.MainMenus.AddOrUpdate(x => x.Id,
            new MainMenu() { Id = "Role", MainMenuName = "Role" },
            new MainMenu() { Id = "Permission", MainMenuName = "Permission" },
            new MainMenu() { Id = "Report", MainMenuName = "Report" },
            new MainMenu() { Id = "Branch", MainMenuName = "Branch" },
             new MainMenu() { Id = "ItemUnit", MainMenuName = "Item Unit" }


          //new MainMenu() { Id = "Doctor", MainMenuName = "Doctor" },
          //new MainMenu() { Id = "ReferelLab", MainMenuName = "Referel Lab" },
          //new MainMenu() { Id = "Department", MainMenuName = "Department" },
          //new MainMenu() { Id = "Patients", MainMenuName = "Patients" },
          //new MainMenu() { Id = "Specimens", MainMenuName = "Specimens" },
          //new MainMenu() { Id = "Unit", MainMenuName = "Unit" },
          //new MainMenu() { Id = "Test", MainMenuName = "Test" },
          //new MainMenu() { Id = "Invoice", MainMenuName = "Invoice" }

          );


            context.SubMenus.AddOrUpdate(x => x.SubMenuName,
                      new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Permission", Controller = "Permissions", Action = "Create", MainMenuId = "Permission" },
                      new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Branch", Controller = "Branches", Action = "Create", MainMenuId = "Branch" },
                      new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Role", Controller = "CustomRoles", Action = "Create", MainMenuId = "Role" },
                      new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "View Report", Controller = "ReportController", Action = "ParameterEntry", MainMenuId = "Report" },




                      new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Unit", Controller = "ItemUnits", Action = "Create", MainMenuId = "ItemUnit" }








                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Doctor", Controller = "Doctors", Action = "Create", MainMenuId = "Doctor" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Department", Controller = "Departments", Action = "Create", MainMenuId = "Department" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Invoice", Controller = "Invoice", Action = "Create", MainMenuId = "Invoice" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Update Invoice", Controller = "Invoice", Action = "InvoiceSearch", MainMenuId = "Invoice" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Patient", Controller = "Patients", Action = "Create", MainMenuId = "Patients" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New ReferelLab", Controller = "ReferelLabs", Action = "Create", MainMenuId = "ReferelLab" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Specimen", Controller = "Specimens", Action = "Create", MainMenuId = "Specimens" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Test", Controller = "Tests", Action = "Create", MainMenuId = "Test" },
                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Add New Unit", Controller = "Units", Action = "Create", MainMenuId = "Unit" },

                     //new SubMenu() { Id = Guid.NewGuid(), SubMenuName = "Due Payment", Controller = "Invoice", Action = "DuePayment", MainMenuId = "Invoice" },

                     );




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Create_Role();
        }



        public void Create_Role()
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));


            if (!roleManager.RoleExists("Admin(D)"))
            {
                var db = new ApplicationDbContext();
                var role = new IdentityRole();
                role.Id = "Admin(D)";
                role.Name = "Admin(D)";
                roleManager.Create(role);
                CustomRole customRole = new CustomRole();
                customRole.Id = role.Id;
                customRole.Name = role.Name;
                db.CustomRoles.Add(customRole);
                db.SaveChanges();
            }
        }


    }
}
