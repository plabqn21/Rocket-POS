namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderCode = c.Long(),
                        OrderDate = c.DateTime(),
                        PatientId = c.Guid(),
                        DoctorId = c.Guid(),
                        TestId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Orders", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Orders", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Orders", new[] { "TestId" });
            DropIndex("dbo.Orders", new[] { "DoctorId" });
            DropIndex("dbo.Orders", new[] { "PatientId" });
            DropTable("dbo.Orders");
        }
    }
}
