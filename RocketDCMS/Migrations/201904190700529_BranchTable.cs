namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BranchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BranchCode = c.String(nullable: false, maxLength: 4),
                        BranchName = c.String(nullable: false, maxLength: 50),
                        OpeningDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        CloseDate = c.DateTime(),
                        BranchStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Branches");
        }
    }
}
