namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoifyUnknown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomRoles", "Name", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomRoles", "Name", c => c.String(maxLength: 256));
        }
    }
}
