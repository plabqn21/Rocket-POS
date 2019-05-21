namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyBranchTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "BranchCode", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "BranchCode", c => c.Int(nullable: false));
        }
    }
}
