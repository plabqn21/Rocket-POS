namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DoctorName = c.String(nullable: false, maxLength: 100),
                        Qualification = c.String(nullable: false, maxLength: 100),
                        Hospital = c.String(nullable: false, maxLength: 100),
                        Remarks = c.String(nullable: false, maxLength: 200),
                        BranchId = c.Guid(nullable: false),
                        CommissionRate = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "BranchId", "dbo.Branches");
            DropIndex("dbo.Doctors", new[] { "BranchId" });
            DropTable("dbo.Doctors");
        }
    }
}
