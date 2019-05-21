namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UnitName = c.String(nullable: false, maxLength: 50),
                        UnitCode = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Units");
        }
    }
}
