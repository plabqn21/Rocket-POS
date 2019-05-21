namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableSubMenuandMainMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainMenus",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100),
                        MainMenuName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubMenuName = c.String(maxLength: 100),
                        Controller = c.String(maxLength: 100),
                        Action = c.String(maxLength: 100),
                        MainMenuId = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainMenus", t => t.MainMenuId)
                .Index(t => t.MainMenuId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "MainMenuId", "dbo.MainMenus");
            DropIndex("dbo.SubMenus", new[] { "MainMenuId" });
            DropTable("dbo.Roles");
            DropTable("dbo.SubMenus");
            DropTable("dbo.MainMenus");
        }
    }
}
