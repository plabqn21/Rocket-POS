namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTables2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Units", "UnitCode", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "UnitCode", c => c.Int(nullable: false));
        }
    }
}
