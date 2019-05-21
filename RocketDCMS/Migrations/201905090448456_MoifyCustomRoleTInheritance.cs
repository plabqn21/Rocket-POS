namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoifyCustomRoleTInheritance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.CustomRoles", "CustomRoleViewModel_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomRoles", "CustomRoleViewModel_Id");
            AddForeignKey("dbo.CustomRoles", "CustomRoleViewModel_Id", "dbo.CustomRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomRoles", "CustomRoleViewModel_Id", "dbo.CustomRoles");
            DropIndex("dbo.CustomRoles", new[] { "CustomRoleViewModel_Id" });
            DropColumn("dbo.CustomRoles", "CustomRoleViewModel_Id");
            DropColumn("dbo.CustomRoles", "Discriminator");
        }
    }
}
