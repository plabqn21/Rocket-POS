namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPermissionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomRoleId = c.String(maxLength: 128),
                        SubMenuId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRoleId)
                .ForeignKey("dbo.SubMenus", t => t.SubMenuId, cascadeDelete: true)
                .Index(t => t.CustomRoleId)
                .Index(t => t.SubMenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "SubMenuId", "dbo.SubMenus");
            DropForeignKey("dbo.Permissions", "CustomRoleId", "dbo.CustomRoles");
            DropIndex("dbo.Permissions", new[] { "SubMenuId" });
            DropIndex("dbo.Permissions", new[] { "CustomRoleId" });
            DropTable("dbo.Permissions");
        }
    }
}
