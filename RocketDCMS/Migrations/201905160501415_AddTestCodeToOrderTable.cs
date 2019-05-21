namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestCodeToOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TestCode", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TestCode");
        }
    }
}
