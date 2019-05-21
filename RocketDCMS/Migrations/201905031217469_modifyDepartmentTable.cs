namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDepartmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Departments", "DepartmentViewModel_Id", c => c.Guid());
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.Int());
            CreateIndex("dbo.Departments", "DepartmentViewModel_Id");
            AddForeignKey("dbo.Departments", "DepartmentViewModel_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "DepartmentViewModel_Id", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "DepartmentViewModel_Id" });
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.Int(nullable: false));
            DropColumn("dbo.Departments", "DepartmentViewModel_Id");
            DropColumn("dbo.Departments", "Discriminator");
        }
    }
}
