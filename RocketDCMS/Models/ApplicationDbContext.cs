using Microsoft.AspNet.Identity.EntityFramework;
using RamsoftBD.Models.Common;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace RamsoftBD.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ReferelLab> ReferelLabs { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Order> Orders { get; set; }
        

        public DbSet<Department> Departments { get; set; }

        public DbSet<Specimen> Specimen { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<InvoiceCheckout> InvoiceCheckouts { get; set; }

        public DbSet<BillTransaction> BillTransactions { get; set; }

        public DbSet<CustomRole> CustomRoles { get; set; }

        public DbSet<MainMenu> MainMenus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        
        internal void ExecuteNonQuery(string Query)
        {
            var cs= System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

           
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(Query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }


            
        }



        internal string GetconnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        }

        public System.Data.Entity.DbSet<RamsoftBD.Models.POS.ItemUnit> ItemUnits { get; set; }

        public System.Data.Entity.DbSet<RamsoftBD.Models.POS.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<RamsoftBD.Models.POS.ItemCatagory> ItemCatagories { get; set; }

        public System.Data.Entity.DbSet<RamsoftBD.Models.POS.ItemSubCatagory> ItemSubCatagories { get; set; }

        public System.Data.Entity.DbSet<RamsoftBD.Models.POS.Item> Items { get; set; }
    }
}