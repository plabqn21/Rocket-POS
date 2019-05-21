namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterDoctorTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "BranchId", "dbo.Branches");
            DropIndex("dbo.Doctors", new[] { "BranchId" });
            AlterColumn("dbo.Doctors", "BranchId", c => c.Guid());
            CreateIndex("dbo.Doctors", "BranchId");
            AddForeignKey("dbo.Doctors", "BranchId", "dbo.Branches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "BranchId", "dbo.Branches");
            DropIndex("dbo.Doctors", new[] { "BranchId" });
            AlterColumn("dbo.Doctors", "BranchId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Doctors", "BranchId");
            AddForeignKey("dbo.Doctors", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
