namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyReferalLabTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReferelLabs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ReferelLabs", "ReferelLabViewModel_Id", c => c.Guid());
            AlterColumn("dbo.ReferelLabs", "ReferelLabCode", c => c.Int());
            CreateIndex("dbo.ReferelLabs", "ReferelLabViewModel_Id");
            AddForeignKey("dbo.ReferelLabs", "ReferelLabViewModel_Id", "dbo.ReferelLabs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReferelLabs", "ReferelLabViewModel_Id", "dbo.ReferelLabs");
            DropIndex("dbo.ReferelLabs", new[] { "ReferelLabViewModel_Id" });
            AlterColumn("dbo.ReferelLabs", "ReferelLabCode", c => c.String(nullable: false, maxLength: 4));
            DropColumn("dbo.ReferelLabs", "ReferelLabViewModel_Id");
            DropColumn("dbo.ReferelLabs", "Discriminator");
        }
    }
}
