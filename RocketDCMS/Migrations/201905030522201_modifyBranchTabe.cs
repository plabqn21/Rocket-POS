namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyBranchTabe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "OpeningDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "OpeningDate", c => c.DateTime(nullable: false));
        }
    }
}
