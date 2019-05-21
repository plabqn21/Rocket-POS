namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PatientName = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        AgeType = c.String(nullable: false, maxLength: 20),
                        BloodGroup = c.String(maxLength: 5),
                        Address = c.String(maxLength: 200),
                        MobileNumber = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Remarks = c.String(maxLength: 200),
                        BranchId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.ReferelLabs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ReferelLabName = c.String(nullable: false, maxLength: 50),
                        ReferelLabCode = c.String(nullable: false, maxLength: 4),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "BranchId", "dbo.Branches");
            DropIndex("dbo.Patients", new[] { "BranchId" });
            DropTable("dbo.ReferelLabs");
            DropTable("dbo.Patients");
        }
    }
}
