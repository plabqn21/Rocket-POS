namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSpecimenTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specimen",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SpecimenName = c.String(nullable: false, maxLength: 50),
                        SpecimenCode = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specimen");
        }
    }
}
