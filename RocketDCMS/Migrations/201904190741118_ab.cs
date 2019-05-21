namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "BranchId", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Role");
            DropColumn("dbo.AspNetUsers", "BranchId");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
