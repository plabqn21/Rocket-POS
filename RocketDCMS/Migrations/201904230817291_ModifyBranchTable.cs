namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyBranchTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Branches", "BranchViewModel_Id", c => c.Guid());
            CreateIndex("dbo.Branches", "BranchViewModel_Id");
            AddForeignKey("dbo.Branches", "BranchViewModel_Id", "dbo.Branches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "BranchViewModel_Id", "dbo.Branches");
            DropIndex("dbo.Branches", new[] { "BranchViewModel_Id" });
            DropColumn("dbo.Branches", "BranchViewModel_Id");
            DropColumn("dbo.Branches", "Discriminator");
        }
    }
}
