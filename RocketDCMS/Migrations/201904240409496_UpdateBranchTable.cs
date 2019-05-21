namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBranchTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "BranchCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "BranchCode", c => c.String(nullable: false, maxLength: 4));
        }
    }
}
