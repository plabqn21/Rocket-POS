namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameRoleTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "CustomRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CustomRoles", newName: "Roles");
        }
    }
}
