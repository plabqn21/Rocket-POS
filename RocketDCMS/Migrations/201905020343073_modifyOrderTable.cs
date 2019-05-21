namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Branch_Id", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Branch_Id");
        }
    }
}
