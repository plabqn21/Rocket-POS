namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoifyPermissionTableInharitence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Permissions", "PermissionViewModel_Id", c => c.Guid());
            CreateIndex("dbo.Permissions", "PermissionViewModel_Id");
            AddForeignKey("dbo.Permissions", "PermissionViewModel_Id", "dbo.Permissions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "PermissionViewModel_Id", "dbo.Permissions");
            DropIndex("dbo.Permissions", new[] { "PermissionViewModel_Id" });
            DropColumn("dbo.Permissions", "PermissionViewModel_Id");
            DropColumn("dbo.Permissions", "Discriminator");
        }
    }
}
