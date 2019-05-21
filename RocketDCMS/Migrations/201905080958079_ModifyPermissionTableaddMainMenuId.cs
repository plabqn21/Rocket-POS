namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPermissionTableaddMainMenuId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "MainMenuId", c => c.String(maxLength: 100));
            CreateIndex("dbo.Permissions", "MainMenuId");
            AddForeignKey("dbo.Permissions", "MainMenuId", "dbo.MainMenus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "MainMenuId", "dbo.MainMenus");
            DropIndex("dbo.Permissions", new[] { "MainMenuId" });
            DropColumn("dbo.Permissions", "MainMenuId");
        }
    }
}
